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

        [HttpGet("env/{variable}")]
        public string Env(string variable) =>
           Environment.GetEnvironmentVariable(variable);

        [HttpGet]
        public ActionResult<string> Index() =>
            Environment.MachineName;
    }
}
