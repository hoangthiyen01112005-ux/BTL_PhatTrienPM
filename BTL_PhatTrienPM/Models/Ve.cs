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

    public int? MaDichVu { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual DichVu? MaDichVuNavigation { get; set; }

    public virtual ICollection<PhanHoi> PhanHois { get; set; } = new List<PhanHoi>();
}
