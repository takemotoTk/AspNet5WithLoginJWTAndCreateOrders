using AppSale.Controllers.Base;
using AppSale.Domain.Common;
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
    [Authorize]
    public class OrderController : ApiControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<int>> Create(OrderRequest request)
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

        [HttpGet()]
        public async Task<ActionResult<PaginatedList<OrderResponse>>> GetAll([FromQuery] OrderQueryRequest request)
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
