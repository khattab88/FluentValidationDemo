using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] User user)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Created("", user);
        } 
    }
}
