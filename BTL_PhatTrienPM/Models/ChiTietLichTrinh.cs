using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class ChiTietLichTrinh
{
    public int MaDichVu { get; set; }

    public int MaDiaDiem { get; set; }

    public string? ThuTu { get; set; }

    public string? ThoiGianGheTham { get; set; }

    public virtual DiaDiem MaDiaDiemNavigation { get; set; } = null!;

    public virtual DichVu MaDichVuNavigation { get; set; } = null!;
}
