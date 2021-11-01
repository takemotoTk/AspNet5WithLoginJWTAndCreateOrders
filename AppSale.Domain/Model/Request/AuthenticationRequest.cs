using AppSale.Domain.Model.Response;
using MediatR;

namespace AppSale.Domain.Model.Request
{
    public class AuthenticationRequest : IRequest<TokenResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
