using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webSwagger.Base
{
    public class ResponseHelper
    {
        public static ApiResponse CreateApiResponse(int result, string msg)
        {
            return new ApiResponse(new ResponseEntity() { Result = result, ErrMsg = msg });
        }

        public static ApiResponse CreateApiResponse<T>(int result, string msg, T data)
        {
            return new ApiResponse(new ResponseEntity() { Result = result, ErrMsg = msg, Data = data });
        }

        public static ApiResponse CreateApiResponse<T>(int result, string msg, string statusCode = null, T data = null) where T : class
        {
            return new ApiResponse(new ResponseEntity() { Result = result, ErrMsg = msg, StatusCode = statusCode, Data = data });
        }

        public static ApiResponse ValidateApiResponse(bool blnExist)
        {
            var entity = new { valid = blnExist };
            return new ApiResponse(entity);
        }
    }
}