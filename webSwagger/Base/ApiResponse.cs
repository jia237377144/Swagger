using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using webSwagger.Helper;

namespace webSwagger.Base
{
    public class ApiResponse:HttpResponseMessage
    {
        public ApiResponse()
            : base(HttpStatusCode.OK)
        {

        }

        public ApiResponse(object content)
            : base(HttpStatusCode.OK)
        {
            this.Content = new StringContent(Serializer.ToJson(content), Encoding.UTF8, "application/json");
        }

    }
}