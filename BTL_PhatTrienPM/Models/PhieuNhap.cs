using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class PhieuNhap
{
    public int MaPhieuNhap { get; set; }

    public DateOnly? NgayLap { get; set; }

    public decimal? TongGiaTri { get; set; }

    public string? TrangThai { get; set; }

    public int? MaDoiTac { get; set; }

    public int? MaNhanVien { get; set; }

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual DoiTac? MaDoiTacNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
