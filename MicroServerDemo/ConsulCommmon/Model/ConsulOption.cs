using System;
namespace ConsulCommmon.Model
{
    public class ConsulOption
    {
        /// <summary>
        /// consul 服务地址
        /// </summary>
        public string ConsulAddress { get; set; }
        /// <summary>
        /// 服务名 [分组]
        /// </summary>
        public string ServiceName { get; set; }
        /// <summary>
        /// 服务绑定IP
        /// </summary>
        public string ServiceIP { get; set; }
        /// <summary>
        /// 服务绑定端口
        /// </summary>
        public int ServicePort { get; set; }
        /// <summary>
        /// 健康检查地址
        /// </summary>
        public string ServiceHealthCheck { get; set; }
        /// <summary>
        /// 服务启动多久后注册
        /// </summary>
        public int DeregisterCriticalServiceAfter { get; set; } = 5;
        /// <summary>
        /// 健康检查时间间隔
        /// </summary>
        public int Interval { get; set; } = 10;
        /// <summary>
        /// 服务超时时间
        /// </summary>
        public int Timeout { get; set; } = 5;
    }
}
