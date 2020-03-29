using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Server1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsulCheckController : ControllerBase
    {
        /// <summary>
        /// Consul 心跳检测
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Get()
        {
            return Ok();
        }
    }
}
