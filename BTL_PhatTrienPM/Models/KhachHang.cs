using System;
using System.Collections.Generic;

namespace BTL_PhatTrienPM.Models;

public partial class KhachHang
{
    public int MaKhachHang { get; set; }

    public string? HoTen { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public int? MaTaiKhoan { get; set; }

    public virtual ICollection<GioHang> GioHangs { get; set; } = new List<GioHang>();

    public virtual ICollection<HoaDonBan> HoaDonBans { get; set; } = new List<HoaDonBan>();

    public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }

    public virtual ICollection<PhanHoi> PhanHois { get; set; } = new List<PhanHoi>();
}
