using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class DoiTac
{
    public int MaDoiTac { get; set; }

    public string? TenDoiTac { get; set; }

    public string? DiaChi { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<DichVu> DichVus { get; set; } = new List<DichVu>();

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
}
