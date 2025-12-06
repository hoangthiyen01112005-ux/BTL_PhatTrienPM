using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class DiaDiem
{
    public int MaDiaDiem { get; set; }

    public string? TenDiaDiem { get; set; }

    public string? DiaChi { get; set; }

    public string? MoTa { get; set; }

    public string? HinhAnh { get; set; }

    public virtual ICollection<ChiTietLichTrinh> ChiTietLichTrinhs { get; set; } = new List<ChiTietLichTrinh>();
}
