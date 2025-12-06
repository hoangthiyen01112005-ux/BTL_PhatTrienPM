using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class NoiDung
{
    public int MaNoiDung { get; set; }

    public string? TieuDe { get; set; }

    public string? ChiTietNoiDung { get; set; }

    public DateOnly? NgayDang { get; set; }

    public int? MaNhanVien { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }
}
