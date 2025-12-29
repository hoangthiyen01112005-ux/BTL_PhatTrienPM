using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class NhanVien
{
    public int MaNhanVien { get; set; }

    public string? HoTen { get; set; }

    public string? Email { get; set; }

    public string? Sdt { get; set; }

    public string? ChucVu { get; set; }

    public int? MaTaiKhoan { get; set; }

    public virtual ICollection<HoaDonBan> HoaDonBans { get; set; } = new List<HoaDonBan>();

    public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }

    public virtual ICollection<NoiDung> NoiDungs { get; set; } = new List<NoiDung>();

    public virtual ICollection<PhieuNhap> PhieuNhaps { get; set; } = new List<PhieuNhap>();
}
