using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SilverQueen.Presentation.Controllers
{
    [EnableCors("DefaultPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        [HttpPost]
        public IActionResult POST() 
        {

            return Ok();

        }

        [HttpPut]
        public IActionResult PUT()
        {

            return Ok();

        }

        [HttpDelete("{id:int}")]
        public IActionResult DELETE(int id)
        {

            return Ok();

        }

        [HttpGet()]
        public IActionResult GET()
        {

            return Ok();

        }

        [HttpGet("{id:int}")]
        public IActionResult GET(int id)
        {

            return Ok();

        }
    }
}