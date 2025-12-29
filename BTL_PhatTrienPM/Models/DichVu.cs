using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class DichVu
{
    public int MaDichVu { get; set; }

    public string? TenDichVu { get; set; }

    public string? LoaiDichVu { get; set; }

    public string? HinhAnh { get; set; }

    public string? LinkBanDo { get; set; }

    public int? MaDoiTac { get; set; }

    public decimal? GiaNhap { get; set; }

    public virtual ICollection<ChiTietLichTrinh> ChiTietLichTrinhs { get; set; } = new List<ChiTietLichTrinh>();

    public virtual ICollection<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; } = new List<ChiTietPhieuNhap>();

    public virtual DoiTac? MaDoiTacNavigation { get; set; }
}
