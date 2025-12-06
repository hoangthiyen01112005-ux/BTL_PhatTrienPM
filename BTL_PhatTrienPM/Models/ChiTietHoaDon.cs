using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class ChiTietHoaDon
{
    public int MaHoaDon { get; set; }

    public int MaVe { get; set; }

    public int? SoLuong { get; set; }

    public decimal? DonGia { get; set; }

    public decimal? GiamGia { get; set; }

    public virtual HoaDonBan MaHoaDonNavigation { get; set; } = null!;

    public virtual Ve MaVeNavigation { get; set; } = null!;
}
