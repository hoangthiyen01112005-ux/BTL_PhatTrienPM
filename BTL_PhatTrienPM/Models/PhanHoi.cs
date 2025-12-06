using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class PhanHoi
{
    public int MaPhanHoi { get; set; }

    public string? NoiDung { get; set; }

    public int? DanhGia { get; set; }

    public DateOnly? NgayGui { get; set; }

    public bool? TrangThaiDuyet { get; set; }

    public int? MaKhachHang { get; set; }

    public int? MaVe { get; set; }

    public virtual KhachHang? MaKhachHangNavigation { get; set; }

    public virtual Ve? MaVeNavigation { get; set; }
}
