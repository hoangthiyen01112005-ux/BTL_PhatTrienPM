using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class Ve
{
    public int MaVe { get; set; }

    public string? TenVe { get; set; }

    public string? MoTa { get; set; }

    public decimal? GiaBan { get; set; }

    public int? SoChoToiDa { get; set; }

    public string? HinhAnh { get; set; }

    public string? LinkBanDo { get; set; }

    public DateOnly? NgayTao { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual ICollection<ChiTietLichTrinh> ChiTietLichTrinhs { get; set; } = new List<ChiTietLichTrinh>();

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual ICollection<PhanHoi> PhanHois { get; set; } = new List<PhanHoi>();
}
