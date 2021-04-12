using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presentation_WebApi.Responses.Exceptions
{
    public class HttpStatusExceptionBase : Exception
    {
        public HttpStatusCode Status { get; private set; }

        public HttpStatusExceptionBase(HttpStatusCode status, string msg) : base(msg)
        {
            Status = status;
        }
    }
}
