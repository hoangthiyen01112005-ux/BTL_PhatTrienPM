using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class GioHang
{
    public int MaGioHang { get; set; }

    public int MaKhachHang { get; set; }

    public int MaVe { get; set; }

    public int? SoLuong { get; set; }

    public DateTime? NgayThem { get; set; }

    public virtual KhachHang MaKhachHangNavigation { get; set; } = null!;

    public virtual Ve MaVeNavigation { get; set; } = null!;
}
