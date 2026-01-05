using Microsoft.AspNetCore.Mvc;
using BTL_PhatTrienPM.DTOs;
using BTL_PhatTrienPM.Services.Interfaces;

namespace BTL_PhatTrienPM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GioHangsController : ControllerBase
    {
        private readonly IGioHangService _gioHangService;

        public GioHangsController(IGioHangService gioHangService)
        {
            _gioHangService = gioHangService;
        }

        // Lấy giỏ hàng của khách (Ví dụ: /api/GioHangs/1)
        [HttpGet("{maKhachHang}")]
        public IActionResult GetCart(int maKhachHang)
        {
            return Ok(_gioHangService.GetGioHangByKhachHang(maKhachHang));
        }

        // Thêm vào giỏ
        [HttpPost]
        public IActionResult AddToCart(GioHangInputDTO input)
        {
            _gioHangService.AddToCart(input);
            return Ok(new { message = "Đã thêm vào giỏ hàng!" });
        }

        // Xóa khỏi giỏ (Ví dụ: /api/GioHangs/5)
        [HttpDelete("{maGioHang}")]
        public IActionResult RemoveFromCart(int maGioHang)
        {
            _gioHangService.RemoveFromCart(maGioHang);
            return Ok(new { message = "Đã xóa sản phẩm khỏi giỏ!" });
        }
    }
}