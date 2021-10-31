using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace projectAnhedonia_back.Presentation.ExceptionFilter
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(new Result<string>("error",context.Exception.Message, ""));
        }
    }
}