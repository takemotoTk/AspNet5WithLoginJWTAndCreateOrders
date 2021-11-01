using AppSale.Domain.Model.Request;
using AppSale.Domain.Model.Response;
using MediatR;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Principal;
using AppSale.Domain.Entities.Security;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using AppSale.Common.Helper;
using AppSale.Domain.Validator;
using System.Collections.Generic;

namespace AppSale.Application.Services
{
    public class AuthenticationServiceManager : IRequestHandler<AuthenticationRequest, TokenResponse>
    {
        private UserManager<AuthorizationUserDB> _userManager;
        private SignInManager<AuthorizationUserDB> _signInManager;
        private SigningConfiguration _signingConfigurations;
        private TokenConfiguration _tokenConfigurations;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthenticationServiceManager(
            SigningConfiguration signingConfigurations,
            TokenConfiguration tokenConfigurations,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AuthorizationUserDB> signInManager,
            UserManager<AuthorizationUserDB> userManager)
        {
            _signInManager = signInManager;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public Task<TokenResponse> Handle(AuthenticationRequest request, CancellationToken cancellationToken)
        {
            return ValidateCredentialsAsync(request);
        }

        public async Task<TokenResponse> ValidateCredentialsAsync(AuthenticationRequest request)
        {
            List<ValidateError> errors = null;
            try
            {
                string userRole = "";
                errors = Helper.Instance.ValidateObj<AuthenticationValidator>(request);
                if (errors != null)
                {
                    throw new Exception();
                }

                var userIdentity = await _userManager.FindByNameAsync(request.UserName);
                if (userIdentity != null)
                {
                    var makeLogin = await _signInManager.CheckPasswordSignInAsync(userIdentity, request.Password, false);
                    if (makeLogin.Succeeded)
                    {
                        var getUserRole = await _userManager.GetRolesAsync(userIdentity);
                        userRole = getUserRole.FirstOrDefault();
                    }
                    else
                    {
                        throw new Exception("Não foi possível fazer o login");
                    }
                }
                else
                {
                    throw new Exception("Não foi possível fazer o login");
                }

                return await GenerateTokenAsync(request, userRole);
            }
            catch (Exception err)
            {
                err = Helper.Instance.MapperException(err, errors);
                throw;
            }
        }

        private async Task<TokenResponse> GenerateTokenAsync(AuthenticationRequest request, string userRole)
        {
            try
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(request.UserName, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, request.UserName),
                        new Claim(ClaimTypes.Role, userRole)
                    }
                );

                DateTime createdDate = DateTime.Now;
                DateTime expirationDate = createdDate + TimeSpan.FromHours(_tokenConfigurations.Hours);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = createdDate,
                    Expires = expirationDate
                });
                var token = handler.WriteToken(securityToken);

                return new TokenResponse()
                {
                    Authenticated = true,
                    Created = createdDate,
                    Expiration = expirationDate,
                    AccessToken = token
                };
            }
            catch (Exception err)
            {
                err = Helper.Instance.MapperException(err);
                throw;
            }
        }
    }
}
