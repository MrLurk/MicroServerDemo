using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Server2.Controllers
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
        /// 获取订单
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetUserOrder()
        {
            _logger.LogError("日志： Server2 ----  Home/GetUserOrder" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            return Ok(new { OrderNum = Guid.NewGuid().ToString("X"), OrderRemark = "测试订单", Amount = new Random().Next(100, 199) });
        }


        [HttpGet("Exception")]
        public ActionResult GetException()
        {
            _logger.LogError("Server2 服务器异常： Server1 ----  Home/Exception" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            throw new Exception("Server2 服务器异常");
        }
    }
}
