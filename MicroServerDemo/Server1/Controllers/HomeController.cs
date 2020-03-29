using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Server1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    { 
        private readonly ILogger<HomeController> _logger = null;  
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUserInfo()
        {
            _logger.LogError("日志： Server1 ----  Home/GetUserInfo" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            return Ok(new { Name = "张三", Age = 18, Address = "广东深圳" });
        }

        [HttpGet("Exception")]
        public ActionResult GetException()
        {
            _logger.LogError("Server1 服务器异常： Server1 ----  Home/Exception" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            throw new Exception("Server1 服务器异常");
        }
    }
}
