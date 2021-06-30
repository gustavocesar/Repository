using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.Contracts;

namespace Repository.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FooController : ControllerBase
    {
        private readonly IFooCommandServiceApplication _commandServiceApp;

        public FooController(IFooCommandServiceApplication commandServiceApp)
        {
            _commandServiceApp = commandServiceApp;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _commandServiceApp.FooAndBar();
            return Ok(true);
        }
    }
}
