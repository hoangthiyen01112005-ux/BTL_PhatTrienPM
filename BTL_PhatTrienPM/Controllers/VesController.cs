using BTL_PhatTrienPM.DTOs;
using BTL_PhatTrienPM.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BTL_PhatTrienPM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VesController : ControllerBase
    {
        private readonly IVeService _veService;

        // Tiêm Service vào Controller (Dependency Injection)
        public VesController(IVeService veService)
        {
            _veService = veService;
        }

        // Lấy danh sách vé
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_veService.GetAllVe());
        }

        // Lấy chi tiết 1 vé
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var ve = _veService.GetVeById(id);
            if (ve == null) return NotFound();
            return Ok(ve);
        }

        // Thêm vé mới
        [HttpPost]
        public IActionResult Create(VeDTO veDto)
        {
            _veService.AddVe(veDto);
            return Ok(new { message = "Thêm vé thành công!" });
        }

        // Sửa vé
        [HttpPut("{id}")]
        public IActionResult Update(int id, VeDTO veDto)
        {
            _veService.UpdateVe(id, veDto);
            return Ok(new { message = "Cập nhật vé thành công!" });
        }

        // Xóa vé
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _veService.DeleteVe(id);
            return Ok(new { message = "Xóa vé thành công!" });
        }
    }
}
