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

    public virtual DbSet<Ve> Ves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC01\\SQLEXPRESS;Database=DA_TRAVEL;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaVe }).HasName("PK__ChiTietH__612C803BF5CDCB4C");

            entity.ToTable("ChiTietHoaDon");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaHoa__59063A47");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaVe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHoa__MaVe__59FA5E80");
        });

        modelBuilder.Entity<ChiTietLichTrinh>(entity =>
        {
            entity.HasKey(e => e.MaLichTrinh).HasName("PK__ChiTietL__32E7201D1D2848E5");

            entity.ToTable("ChiTietLichTrinh");

            entity.Property(e => e.ThoiGian).HasMaxLength(100);

            entity.HasOne(d => d.MaDiaDiemNavigation).WithMany(p => p.ChiTietLichTrinhs)
                .HasForeignKey(d => d.MaDiaDiem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietLi__MaDia__4AB81AF0");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.ChiTietLichTrinhs)
                .HasForeignKey(d => d.MaDichVu)
                .HasConstraintName("FK__ChiTietLi__MaDic__4BAC3F29");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.ChiTietLichTrinhs)
                .HasForeignKey(d => d.MaVe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietLic__MaVe__49C3F6B7");
        });

        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => new { e.MaPhieuNhap, e.MaDichVu }).HasName("PK__ChiTietP__F87E82D3DD2F2765");

            entity.ToTable("ChiTietPhieuNhap");

            entity.Property(e => e.DonGiaNhap).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaDic__628FA481");

            entity.HasOne(d => d.MaPhieuNhapNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaPhieuNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaPhi__619B8048");
        });

        modelBuilder.Entity<DiaDiem>(entity =>
        {
            entity.HasKey(e => e.MaDiaDiem).HasName("PK__DiaDiem__F015962A616072E4");

            entity.ToTable("DiaDiem");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.TenDiaDiem).HasMaxLength(100);
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu).HasName("PK__DichVu__C0E6DE8F9F78A6A0");

            entity.ToTable("DichVu");

            entity.Property(e => e.GiaNhap).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.LoaiDichVu).HasMaxLength(50);
            entity.Property(e => e.TenDichVu).HasMaxLength(150);

            entity.HasOne(d => d.MaDoiTacNavigation).WithMany(p => p.DichVus)
                .HasForeignKey(d => d.MaDoiTac)
                .HasConstraintName("FK__DichVu__MaDoiTac__440B1D61");
        });

        modelBuilder.Entity<DoiTac>(entity =>
        {
            entity.HasKey(e => e.MaDoiTac).HasName("PK__DoiTac__5F76BF34A08F183E");

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
            entity.HasKey(e => e.MaGioHang).HasName("PK__GioHang__F5001DA3BAB720B7");

            entity.ToTable("GioHang");

            entity.Property(e => e.NgayThem)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.SoLuong).HasDefaultValue(1);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GioHang__MaKhach__5070F446");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.GioHangs)
                .HasForeignKey(d => d.MaVe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GioHang__MaVe__5165187F");
        });

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDonBa__835ED13BCA0601A7");

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__HoaDonBan__MaKha__5535A963");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__HoaDonBan__MaNha__5629CD9C");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E50E6B8177");

            entity.ToTable("KhachHang");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.MaTaiKhoan)
                .HasConstraintName("FK__KhachHang__MaTai__3D5E1FD2");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA476EBEE1F9");

            entity.ToTable("NhanVien");

            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaTaiKhoan)
                .HasConstraintName("FK__NhanVien__MaTaiK__3A81B327");
        });

        modelBuilder.Entity<NoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNoiDung).HasName("PK__NoiDung__55BA6C624BDFE58F");

            entity.ToTable("NoiDung");

            entity.Property(e => e.TieuDe).HasMaxLength(200);

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.NoiDungs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__NoiDung__MaNhanV__6A30C649");
        });

        modelBuilder.Entity<PhanHoi>(entity =>
        {
            entity.HasKey(e => e.MaPhanHoi).HasName("PK__PhanHoi__3458D20FA3FF254D");

            entity.ToTable("PhanHoi");

            entity.Property(e => e.NgayGui)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.PhanHois)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__PhanHoi__MaKhach__66603565");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.PhanHois)
                .HasForeignKey(d => d.MaVe)
                .HasConstraintName("FK__PhanHoi__MaVe__6754599E");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasKey(e => e.MaPhieuNhap).HasName("PK__PhieuNha__1470EF3B93BF4DEE");

            entity.ToTable("PhieuNhap");

            entity.Property(e => e.NgayLap)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.TongGiaTri).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.MaDoiTacNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaDoiTac)
                .HasConstraintName("FK__PhieuNhap__MaDoi__5DCAEF64");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__PhieuNhap__MaNha__5EBF139D");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C65292E0721F5");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC0CE6131EE").IsUnique();

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

        modelBuilder.Entity<Ve>(entity =>
        {
            entity.HasKey(e => e.MaVe).HasName("PK__Ve__2725100F46D0D4D2");

            entity.ToTable("Ve");

            entity.Property(e => e.GiaBan).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.NgayTao).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TenVe).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
