using BTL_PhatTrienPM.Models;
using BTL_PhatTrienPM.DTOs;
using BTL_PhatTrienPM.Services.Interfaces;

namespace BTL_PhatTrienPM.Services.Implements
{
    public class GioHangService : IGioHangService
    {
        private readonly DaTravelContext _context;

        public GioHangService(DaTravelContext context)
        {
            _context = context;
        }

        public List<GioHangOutputDTO> GetGioHangByKhachHang(int maKhachHang)
        {
            // Join bảng Giỏ hàng với bảng Vé để lấy tên và giá
            var list = _context.GioHangs
                .Where(g => g.MaKhachHang == maKhachHang)
                .Select(g => new GioHangOutputDTO
                {
                    MaGioHang = g.MaGioHang,
                    MaVe = g.MaVe,
                    TenVe = g.Ve.TenVe,       // Lấy tên từ bảng Ve
                    HinhAnh = g.Ve.HinhAnh,   // Lấy ảnh từ bảng Ve
                    GiaBan = (decimal)g.Ve.GiaBan,
                    SoLuong = (int)g.SoLuong,
                    ThanhTien = (decimal)(g.Ve.GiaBan * g.SoLuong)
                }).ToList();

            return list;
        }

        public void AddToCart(GioHangInputDTO input)
        {
            // Kiểm tra xem vé này đã có trong giỏ của khách chưa
            var existingItem = _context.GioHangs
                .FirstOrDefault(g => g.MaKhachHang == input.MaKhachHang && g.MaVe == input.MaVe);

            if (existingItem != null)
            {
                // Nếu có rồi thì cộng dồn số lượng
                existingItem.SoLuong += input.SoLuong;
            }
            else
            {
                // Chưa có thì thêm mới
                var newItem = new GioHang
                {
                    MaKhachHang = input.MaKhachHang,
                    MaVe = input.MaVe,
                    SoLuong = input.SoLuong,
                    NgayThem = DateTime.Now
                };
                _context.GioHangs.Add(newItem);
            }
            _context.SaveChanges();
        }

        public void RemoveFromCart(int maGioHang)
        {
            var item = _context.GioHangs.Find(maGioHang);
            if (item != null)
            {
                _context.GioHangs.Remove(item);
                _context.SaveChanges();
            }
        }
    }
}