using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class ChiTietPhieuNhap
{
    public int MaPhieuNhap { get; set; }

    public int MaDichVu { get; set; }

    public int? SoLuong { get; set; }

    public decimal? DonGiaNhap { get; set; }

    public virtual DichVu MaDichVuNavigation { get; set; } = null!;

    public virtual PhieuNhap MaPhieuNhapNavigation { get; set; } = null!;
}
