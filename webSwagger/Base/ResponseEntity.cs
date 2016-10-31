using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webSwagger.Base
{
    public class ResponseEntity
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        public int Result { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string ErrMsg { get; set; }
        /// <summary>
        /// 状态码
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public Object Data { get; set; }
    }
}