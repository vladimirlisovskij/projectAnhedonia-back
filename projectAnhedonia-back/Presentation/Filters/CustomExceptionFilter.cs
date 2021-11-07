using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using projectAnhedonia_back.Presentation.Entities.Dto;

namespace projectAnhedonia_back.Presentation.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new Result<string>("error", context.Exception.Message, context.Exception.GetType().Name));
        }
    }
}