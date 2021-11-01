using AppSale.Controllers.Base;
using AppSale.Domain.Model.Request;
using AppSale.Domain.Model.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSale.Controllers
{
    public class AuthenticationController : ApiControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<TokenResponse>> AuthenticationLogin(AuthenticationRequest request)
        {
            try
            {
                var response = await Mediator.Send(request);
                return Ok(response);
            }
            catch (Exception err)
            {
                return BadRequest(err.Data);
            }
        }
    }
}
