using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation_WebApi.Responses;
using Presentation_WebApi.Responses.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation_WebApi.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public ErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error; // Your exception
            var code = 500; // Internal Server Error by default

            if (exception is HttpStatusExceptionBase httpStatusExceptionBase)
            {
                code = (int)httpStatusExceptionBase.Status;
            }
            //else if (exception is MyUnauthException) code = 401; // Unauthorized
            //else if (exception is MyException) code = 400; // Bad Request

            Response.StatusCode = code;

            return new ErrorResponse(exception); // Your error model
        }
    }
}
