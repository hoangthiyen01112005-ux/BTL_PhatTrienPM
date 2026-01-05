using System.ComponentModel.DataAnnotations;

namespace BTL_PhatTrienPM.DTOs
{
    public class VeDTO
    {
        public int MaVe { get; set; }

        [Required(ErrorMessage = "Tên vé không được để trống")]
        public string? TenVe { get; set; }

        public string? MoTa { get; set; }
        public decimal? GiaBan { get; set; }
        public int? SoChoToiDa { get; set; }
        public string? HinhAnh { get; set; }
        public string? LinkBanDo { get; set; }
        public DateTime NgayKhoiHanh { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public byte[]? PhienBan { get; set; }
    }
}