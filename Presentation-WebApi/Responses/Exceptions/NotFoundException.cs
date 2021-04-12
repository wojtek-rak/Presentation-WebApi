using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presentation_WebApi.Responses.Exceptions
{
    public class NotFoundException : HttpStatusExceptionBase
    {
        public NotFoundException(string msg) : base(HttpStatusCode.NotFound, msg) {}
    }
}
