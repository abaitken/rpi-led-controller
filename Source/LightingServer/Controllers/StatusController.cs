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
    [Route("api/[controller]")]
    public class StatusController : ControllerBase
    { 
        private readonly ILogger<StatusController> _logger;
        private readonly ILightingService _lightingService;

        public StatusController(ILogger<StatusController> logger, ILightingService lightingService)
        {
            _logger = logger;
            _lightingService = lightingService;
        }

        [HttpGet]
        public LightingStatus Get()
        {
            return new LightingStatus
            {
                Demo = _lightingService.CurrentDemo
            };
        }

        [HttpGet("{id}")]
        public LightingStatus ChangeDemo(string id)
        {
            _lightingService.CurrentDemo = id;
            return Get();
        }
    }
}
