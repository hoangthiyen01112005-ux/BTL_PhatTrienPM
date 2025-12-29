using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class ChiTietLichTrinh
{
    public int MaLichTrinh { get; set; }

    public int MaVe { get; set; }

    public int MaDiaDiem { get; set; }

    public int? MaDichVu { get; set; }

    public string? ThoiGian { get; set; }

    public string? HoatDong { get; set; }

    public virtual DiaDiem MaDiaDiemNavigation { get; set; } = null!;

    public virtual DichVu? MaDichVuNavigation { get; set; }

    public virtual Ve MaVeNavigation { get; set; } = null!;
}
