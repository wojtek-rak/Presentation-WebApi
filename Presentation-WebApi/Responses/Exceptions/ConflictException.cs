using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Presentation_WebApi.Responses.Exceptions
{
    public class ConflictException : HttpStatusExceptionBase
    {
        public ConflictException(string msg) : base(HttpStatusCode.Conflict, msg)
        {
        }
    }
}
