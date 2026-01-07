using Microsoft.AspNetCore.Mvc;

namespace APIadmin.Controllers
{
    [ApiController]
    [Route("api/admin/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly string[] Users = new[]
        {
            "NetCode", "Hub", "MAI"
        };

        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Users);
        }
    }
}
