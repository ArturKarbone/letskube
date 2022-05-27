using Microsoft.AspNetCore.Mvc;
using System;

namespace LetsKube
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticsController : ControllerBase
    {
        [HttpGet("machinename")]
        public string MachineName() =>
            Environment.MachineName;

        [HttpGet]
        public ActionResult<string> Index() =>
            Environment.MachineName;
    }
}
