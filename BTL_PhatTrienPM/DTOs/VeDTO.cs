namespace BTL_PhatTrienPM.DTOs
{
    // 1. DTO dùng để hiển thị (Output) - Gọn nhẹ, dễ đọc
    public class VeDTO
    {
        public int MaVe { get; set; }
        public string TenVe { get; set; }
        public string MoTa { get; set; }
        public decimal GiaBan { get; set; } // Hoặc double tùy database của bạn
        public int SoChoToiDa { get; set; }
        public string TenDichVu { get; set; } // Trả về Tên Dịch Vụ thay vì chỉ trả về Mã số vô nghĩa
    }

    // 2. DTO dùng để Thêm mới/Sửa (Input) - Có validate kiểm tra lỗi
    public class VeCreateDTO
    {
        public string TenVe { get; set; }
        public string MoTa { get; set; }
        public decimal GiaBan { get; set; }
        public int SoChoToiDa { get; set; }
        public int MaDichVu { get; set; } // Khi thêm mới thì cần Mã để nối bảng
    }
}
