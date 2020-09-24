using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Json (DAL.UserInfo.Instance.GetCount());
        }
        [HttpPost("{username}")]
        public ActionResult  post([FromBody]Model.UserInfo users)
        {
            try
            {
                int n = DAL.UserInfo.Instance.Add(users);
                return Json(Result.Ok("添加成功"));
            }
            catch(Exception ex)
            {
                if (ex.Message.ToLower().Contains("primary"))
                    return Json(Result.Err("用户名已存在"));
                else if (ex.Message.ToLower().Contains("null"))
                    return Json(Result.Err("用户名、密码、身份证不能为空"));
                else
                    return Json(Result.Err(ex.Message));
            }
        }
    }
}
