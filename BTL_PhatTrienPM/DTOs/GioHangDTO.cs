namespace BTL_PhatTrienPM.DTOs
{
    // DTO dùng để thêm vào giỏ (Input)
    public class GioHangInputDTO
    {
        public int MaKhachHang { get; set; } // Tạm thời nhập tay, sau này lấy từ Token đăng nhập sau
        public int MaVe { get; set; }
        public int SoLuong { get; set; }
    }

    // DTO dùng để hiển thị danh sách giỏ hàng (Output)
    public class GioHangOutputDTO
    {
        public int MaGioHang { get; set; }
        public int MaVe { get; set; }
        public string TenVe { get; set; }  // Cần tên để khách biết mình mua gì
        public string HinhAnh { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get; set; } // = Giá * Số lượng
    }
}