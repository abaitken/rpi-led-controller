using LightingServer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightingServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    { 
        private readonly ILogger<StatusController> _logger;

        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public LightingStatus Get()
        {
            return new LightingStatus
            {
                Demo = "Ready"
            };
        }
    }
}
