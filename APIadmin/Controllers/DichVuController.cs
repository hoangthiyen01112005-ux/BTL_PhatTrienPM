using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL.Interface;

namespace APIadmin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuController : ControllerBase
    {
        private readonly IBLL_DichVu _bll;
        public DichVuController(IBLL_DichVu bll) { _bll = bll; }

        [HttpGet("get-all")]
        public IActionResult GetAll()
        {
            var res = _bll.GetAll();
            return Ok(res);
        }
    }
}