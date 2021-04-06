using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace powerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productionplanController : ControllerBase
    {


        // POST api/<productionplanController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }
    }
}
