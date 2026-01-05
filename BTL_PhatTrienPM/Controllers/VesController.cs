using BTL_PhatTrienPM.DTOs;
using BTL_PhatTrienPM.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BTL_PhatTrienPM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesController : ControllerBase
    {
        private readonly IVeService _veService;

        public VesController(IVeService veService)
        {
            _veService = veService;
        }

        // --- SỬA LỖI: Chỉ giữ 1 hàm GetAll duy nhất ---
        // Vừa lấy tất cả, vừa hỗ trợ tìm kiếm nếu có keyword truyền vào
        [HttpGet]
        public IActionResult GetAll([FromQuery] string? keyword)
        {
            return Ok(_veService.GetAllVe(keyword));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ve = _veService.GetVeById(id);
            if (ve == null) return NotFound();
            return Ok(ve);
        }

        [HttpPost]
        public IActionResult Create(VeDTO veDto)
        {
            try
            {
                _veService.AddVe(veDto);
                return Ok(new { message = "Thêm vé thành công!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, VeDTO veDto)
        {
            _veService.UpdateVe(id, veDto);
            return Ok(new { message = "Cập nhật vé thành công!" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _veService.DeleteVe(id);
            return Ok(new { message = "Xóa vé thành công!" });
        }
    }
}