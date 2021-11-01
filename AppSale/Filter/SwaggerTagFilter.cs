using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSale.Filter
{
    public class SwaggerTagFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            foreach (var contextApiDescription in context.ApiDescriptions)
            {
                var actionDescriptor = (ControllerActionDescriptor)contextApiDescription.ActionDescriptor;
            }
        }
    }
}
