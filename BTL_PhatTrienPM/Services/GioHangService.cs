using BTL_PhatTrienPM.Models;
using BTL_PhatTrienPM.DTOs;
using BTL_PhatTrienPM.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BTL_PhatTrienPM.Services.Implements
{
    // Phải kế thừa IGioHangService, KHÔNG phải ControllerBase
    public class GioHangService : IGioHangService
    {
        private readonly DaTravelContext _context;

        public GioHangService(DaTravelContext context)
        {
            _context = context;
        }

        public List<GioHangOutputDTO> GetGioHangByKhachHang(int maKhachHang)
        {
            // Kết nối bảng GioHang với bảng Ve
            return _context.GioHangs
                .Include(g => g.MaVeNavigation)
                .Where(g => g.MaKhachHang == maKhachHang)
                .Select(g => new GioHangOutputDTO
                {
                    MaGioHang = g.MaGioHang,

                    // SỬA LỖI LỆCH DATA (như ảnh bạn gửi):
                    // Database là int? (có thể null), DTO là int (bắt buộc)
                    // Dùng "?? 0" nghĩa là: nếu null thì lấy bằng 0
                    MaVe = g.MaVe ?? 0,

                    // Kiểm tra null cho navigation property để tránh lỗi
                    TenVe = g.MaVeNavigation != null ? g.MaVeNavigation.TenVe : "Vé không tồn tại",
                    HinhAnh = g.MaVeNavigation != null ? g.MaVeNavigation.HinhAnh : "",
                    GiaBan = g.MaVeNavigation != null ? (g.MaVeNavigation.GiaBan ?? 0) : 0,

                    SoLuong = g.SoLuong ?? 0,

                    // Tính thành tiền
                    ThanhTien = (g.MaVeNavigation != null ? (g.MaVeNavigation.GiaBan ?? 0) : 0) * (g.SoLuong ?? 0)
                })
                .ToList();
        }

        public void AddToCart(GioHangInputDTO input)
        {
            // Kiểm tra xem đã có vé này trong giỏ chưa
            var existingItem = _context.GioHangs
                .FirstOrDefault(x => x.MaKhachHang == input.MaKhachHang && x.MaVe == input.MaVe);

            if (existingItem != null)
            {
                // Có rồi thì cộng thêm số lượng
                existingItem.SoLuong = (existingItem.SoLuong ?? 0) + input.SoLuong;
            }
            else
            {
                // Chưa có thì tạo mới
                var newItem = new GioHang
                {
                    MaKhachHang = input.MaKhachHang,
                    MaVe = input.MaVe,
                    SoLuong = input.SoLuong,
                    NgayThem = DateTime.Now // Lưu thời gian thêm
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