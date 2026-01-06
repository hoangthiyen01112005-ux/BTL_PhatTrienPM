using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BTL_PhatTrienPM.Models;

public partial class DaTravelContext : DbContext
{
    public DaTravelContext()
    {
    }

    public DaTravelContext(DbContextOptions<DaTravelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }

    public virtual DbSet<ChiTietLichTrinh> ChiTietLichTrinhs { get; set; }

    public virtual DbSet<ChiTietPhieuNhap> ChiTietPhieuNhaps { get; set; }

    public virtual DbSet<DiaDiem> DiaDiems { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<DoiTac> DoiTacs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<HoaDonBan> HoaDonBans { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<NoiDung> NoiDungs { get; set; }

    public virtual DbSet<PhanHoi> PhanHois { get; set; }

    public virtual DbSet<PhieuNhap> PhieuNhaps { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    public virtual DbSet<VThongKeDoanhThuThang> VThongKeDoanhThuThangs { get; set; }

    public virtual DbSet<Ve> Ves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC01\\SQLEXPRESS;Database=DA_TRAVEL;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaVe }).HasName("PK__ChiTietH__612C803B59A6722B");

            entity.ToTable("ChiTietHoaDon", tb => tb.HasTrigger("Trg_CapNhatSoCho"));

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaHoa__6B24EA82");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaVe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHoa__MaVe__6C190EBB");
        });

        modelBuilder.Entity<ChiTietLichTrinh>(entity =>
        {
            entity.HasKey(e => e.MaLichTrinh).HasName("PK__ChiTietL__32E7201D07CB7919");

            entity.ToTable("ChiTietLichTrinh");

            entity.Property(e => e.ThoiGian).HasMaxLength(100);

            entity.HasOne(d => d.MaDiaDiemNavigation).WithMany(p => p.ChiTietLichTrinhs)
                .HasForeignKey(d => d.MaDiaDiem)
                .HasConstraintName("FK__ChiTietLi__MaDia__5629CD9C");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.ChiTietLichTrinhs)
                .HasForeignKey(d => d.MaDichVu)
                .HasConstraintName("FK__ChiTietLi__MaDic__571DF1D5");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.ChiTietLichTrinhs)
                .HasForeignKey(d => d.MaVe)
                .HasConstraintName("FK__ChiTietLic__MaVe__5535A963");
        });

        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => new { e.MaPhieuNhap, e.MaDichVu }).HasName("PK__ChiTietP__F87E82D323174EC4");

            entity.ToTable("ChiTietPhieuNhap");

            entity.Property(e => e.DonGiaNhap).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaDic__787EE5A0");

            entity.HasOne(d => d.MaPhieuNhapNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaPhieuNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaPhi__778AC167");
        });

        modelBuilder.Entity<DiaDiem>(entity =>
        {
            entity.HasKey(e => e.MaDiaDiem).HasName("PK__DiaDiem__F015962A1A671096");

            entity.ToTable("DiaDiem");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.TenDiaDiem).HasMaxLength(100);
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu).HasName("PK__DichVu__C0E6DE8F8766340E");

            entity.ToTable("DichVu");

            entity.Property(e => e.GiaNhap).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.LoaiDichVu).HasMaxLength(50);
            entity.Property(e => e.TenDichVu).HasMaxLength(150);

            entity.HasOne(d => d.MaDoiTacNavigation).WithMany(p => p.DichVus)
                .HasForeignKey(d => d.MaDoiTac)
                .HasConstraintName("FK__DichVu__MaDoiTac__47DBAE45");
        });

        modelBuilder.Entity<DoiTac>(entity =>
        {
            entity.HasKey(e => e.MaDoiTac).HasName("PK__DoiTac__5F76BF3428C9AA1A");

            entity.ToTable("DoiTac");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");
            entity.Property(e => e.TenDoiTac).HasMaxLength(100);
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.MaGioHang).HasName("PK__GioHang__F5001DA32EB8F0DB");

            entity.ToTable("GioHang");

            entity.HasIndex(e => new { e.MaKhachHang, e.MaVe }, "UQ_GioHang").IsUnique();

            entity.Property(e => e.NgayThem)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoLuong).HasDefaultValue(1);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__GioHang__MaKhach__5DCAEF64");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaVe)
                .HasConstraintName("FK__GioHang__MaVe__5EBF139D");
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDonBa__835ED13B13F58FEF");

            entity.ToTable("HoaDonBan");

            entity.HasIndex(e => e.MaKhachHang, "IX_HoaDon_KhachHang");

            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongTien)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TrangThai).HasMaxLength(30);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__HoaDonBan__MaKha__656C112C");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__HoaDonBan__MaNha__66603565");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5A203BCDF");

            entity.ToTable("KhachHang");

            entity.HasIndex(e => e.MaTaiKhoan, "UQ__KhachHan__AD7C65286CCAC58A").IsUnique();

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithOne(p => p.KhachHang)
                .HasForeignKey<KhachHang>(d => d.MaTaiKhoan)
                .HasConstraintName("FK__KhachHang__MaTai__403A8C7D");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA478CB1793B");

            entity.ToTable("NhanVien");

            entity.HasIndex(e => e.MaTaiKhoan, "UQ__NhanVien__AD7C65283E50708F").IsUnique();

            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithOne(p => p.NhanVien)
                .HasForeignKey<NhanVien>(d => d.MaTaiKhoan)
                .HasConstraintName("FK__NhanVien__MaTaiK__3C69FB99");
        });

        modelBuilder.Entity<NoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNoiDung).HasName("PK__NoiDung__55BA6C6269AFA756");

            entity.ToTable("NoiDung");

            entity.Property(e => e.NgayDang)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TieuDe).HasMaxLength(200);

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.NoiDungs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__NoiDung__MaNhanV__02084FDA");
        });

        modelBuilder.Entity<PhanHoi>(entity =>
        {
            entity.HasKey(e => e.MaPhanHoi).HasName("PK__PhanHoi__3458D20F2CBB88F6");

            entity.ToTable("PhanHoi", tb => tb.HasTrigger("Trg_KiemTraQuyenDanhGia"));

            entity.Property(e => e.NgayGui)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.PhanHois)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__PhanHoi__MaKhach__7D439ABD");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.PhanHois)
                .HasForeignKey(d => d.MaVe)
                .HasConstraintName("FK__PhanHoi__MaVe__7E37BEF6");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasKey(e => e.MaPhieuNhap).HasName("PK__PhieuNha__1470EF3BB8B0610E");

            entity.ToTable("PhieuNhap");

            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongGiaTri)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaDoiTacNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaDoiTac)
                .HasConstraintName("FK__PhieuNhap__MaDoi__71D1E811");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__PhieuNhap__MaNha__72C60C4A");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C652934DE3F12");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC05D70F830").IsUnique();

            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QuyenTruyCap)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrangThai).HasDefaultValue(true);
        });

        modelBuilder.Entity<VThongKeDoanhThuThang>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("v_ThongKeDoanhThuThang");

            entity.Property(e => e.TongDoanhThu).HasColumnType("decimal(38, 0)");
        });

        modelBuilder.Entity<Ve>(entity =>
        {
            entity.HasKey(e => e.MaVe).HasName("PK__Ve__2725100F539074C8");

            entity.ToTable("Ve");

            entity.HasIndex(e => e.GiaBan, "IX_Ve_GiaBan");

            entity.HasIndex(e => e.TenVe, "IX_Ve_TenVe");

            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NgayCapNhat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayKetThuc).HasColumnType("datetime");
            entity.Property(e => e.NgayKhoiHanh).HasColumnType("datetime");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PhienBan)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.SoChoDaDat).HasDefaultValue(0);
            entity.Property(e => e.TenVe).HasMaxLength(150);
            entity.Property(e => e.TrangThai).HasDefaultValue(1);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
