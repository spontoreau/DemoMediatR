using DemoMediatR.WebApi.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoMediatR.WebApi.Filters
{
    public class DomainExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            DomainException e = context.Exception as DomainException;

            if(e != null)
            {
                context.Result = new ObjectResult(e.Message) { StatusCode = 400 };
            }
        }
    }
}