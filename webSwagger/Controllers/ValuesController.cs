using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webSwagger.Base;
using webSwagger.JYAPI;

namespace webSwagger.Controllers
{
    [RoutePrefix("api/test")]
    public class ValuesController : BaseApiController
    {
        /// <summary>
        /// 产生验证码
        /// </summary>
        /// <returns></returns>
        [Route("GenerateCode")]
        public ApiResponse GenerateCode()
        {
            Context.Response.ContentType = "application/json";
            GeetestLib geetest = new GeetestLib(GeetestConfig.publicKey, GeetestConfig.privateKey);
            string appKey = System.Guid.NewGuid().ToString();
            Byte gtServerStatus = geetest.preProcess(appKey);
            Context.Session[GeetestLib.gtServerStatusSessionKey] = gtServerStatus;
            Context.Session["sessionID"] = appKey;
            return ResponseHelper.CreateApiResponse(10000,"success",geetest.getResponseStr());
        }
        [Route("ValidCode")]
        public ApiResponse Success()
        {
            GeetestLib geetest = new GeetestLib(GeetestConfig.publicKey, GeetestConfig.privateKey);
            Byte gt_server_status_code = (Byte)Context.Session[GeetestLib.gtServerStatusSessionKey];
            String userID = (String)Context.Session["sessionID"];
            int result = 0;
            String challenge = Context.Request.Form.Get(GeetestLib.fnGeetestChallenge);
            String validate = Context.Request.Form.Get(GeetestLib.fnGeetestValidate);
            String seccode = Context.Request.Form.Get(GeetestLib.fnGeetestSeccode);
            if (gt_server_status_code == 1)
                result = geetest.enhencedValidateRequest(challenge, validate, seccode, userID);
            else
                result = geetest.failbackValidateRequest(challenge, validate, seccode);
            if (result == 1)
                return ResponseHelper.CreateApiResponse(10000,"验证码校验成功");
            else 
                return ResponseHelper.CreateApiResponse(10001,"验证码校验失败");

        }

    }
}
