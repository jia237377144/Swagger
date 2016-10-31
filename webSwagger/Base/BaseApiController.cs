using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace webSwagger.Base
{
    public class BaseApiController : ApiController
    {
       
        protected HttpContext Context
        {
            get { return HttpContext.Current; }
        }
    }
}