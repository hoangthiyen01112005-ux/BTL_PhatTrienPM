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
        => optionsBuilder.UseSqlServer("Server=PC01\\SQLEXPRESS;Database=DA_TRAVEL;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChiTietHoaDon>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDon, e.MaVe }).HasName("PK__ChiTietH__612C803B66053056");

            entity.ToTable("ChiTietHoaDon", tb => tb.HasTrigger("trg_TinhTongTien"));

            entity.Property(e => e.DonGia).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.GiamGia).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaHoaDon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHo__MaHoa__5812160E");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.ChiTietHoaDons)
                .HasForeignKey(d => d.MaVe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietHoa__MaVe__59063A47");
        });

        modelBuilder.Entity<ChiTietLichTrinh>(entity =>
        {
            entity.HasKey(e => new { e.MaDichVu, e.MaDiaDiem }).HasName("PK__ChiTietL__7FE787EDFB640DB1");

            entity.ToTable("ChiTietLichTrinh");

            entity.Property(e => e.ThoiGianGheTham).HasMaxLength(50);
            entity.Property(e => e.ThuTu).HasMaxLength(10);

            entity.HasOne(d => d.MaDiaDiemNavigation).WithMany(p => p.ChiTietLichTrinhs)
                .HasForeignKey(d => d.MaDiaDiem)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietLi__MaDia__46E78A0C");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.ChiTietLichTrinhs)
                .HasForeignKey(d => d.MaDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietLi__MaDic__45F365D3");
        });

        modelBuilder.Entity<ChiTietPhieuNhap>(entity =>
        {
            entity.HasKey(e => new { e.MaPhieuNhap, e.MaDichVu }).HasName("PK__ChiTietP__F87E82D35EA3529F");

            entity.ToTable("ChiTietPhieuNhap", tb => tb.HasTrigger("trg_TinhTongGiaTri"));

            entity.Property(e => e.DonGiaNhap).HasColumnType("decimal(12, 2)");

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaDic__5165187F");

            entity.HasOne(d => d.MaPhieuNhapNavigation).WithMany(p => p.ChiTietPhieuNhaps)
                .HasForeignKey(d => d.MaPhieuNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ChiTietPh__MaPhi__5070F446");
        });

        modelBuilder.Entity<DiaDiem>(entity =>
        {
            entity.HasKey(e => e.MaDiaDiem).HasName("PK__DiaDiem__F015962A65B139B3");

            entity.ToTable("DiaDiem");

            entity.Property(e => e.DiaChi).HasMaxLength(255);
            entity.Property(e => e.HinhAnh).HasMaxLength(255);
            entity.Property(e => e.TenDiaDiem).HasMaxLength(100);
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu).HasName("PK__DichVu__C0E6DE8F0365BFA6");

            entity.ToTable("DichVu");

            entity.Property(e => e.GiaBan).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.GiaNhap).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.LoaiDichVu).HasMaxLength(50);
            entity.Property(e => e.TenDichVu).HasMaxLength(150);

            entity.HasOne(d => d.MaDoiTacNavigation).WithMany(p => p.DichVus)
                .HasForeignKey(d => d.MaDoiTac)
                .HasConstraintName("FK__DichVu__MaDoiTac__4316F928");
        });

        modelBuilder.Entity<DoiTac>(entity =>
        {
            entity.HasKey(e => e.MaDoiTac).HasName("PK__DoiTac__5F76BF340F1D91FB");

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

        modelBuilder.Entity<HoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__HoaDonBa__835ED13B697A570E");

            entity.ToTable("HoaDonBan");

            entity.Property(e => e.TongTien).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__HoaDonBan__MaKha__5441852A");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.HoaDonBans)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__HoaDonBan__MaNha__5535A963");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__KhachHan__88D2F0E5106C9CD8");

            entity.ToTable("KhachHang");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.KhachHangs)
                .HasForeignKey(d => d.MaTaiKhoan)
                .HasConstraintName("FK__KhachHang__MaTai__3C69FB99");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__77B2CA478A47DA24");

            entity.ToTable("NhanVien");

            entity.Property(e => e.ChucVu).HasMaxLength(50);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.GioiTinh).HasMaxLength(10);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.Sdt)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("SDT");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.NhanViens)
                .HasForeignKey(d => d.MaTaiKhoan)
                .HasConstraintName("FK__NhanVien__MaTaiK__398D8EEE");
        });

        modelBuilder.Entity<NoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNoiDung).HasName("PK__NoiDung__55BA6C62B7CA2273");

            entity.ToTable("NoiDung");

            entity.Property(e => e.TieuDe).HasMaxLength(200);

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.NoiDungs)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__NoiDung__MaNhanV__5FB337D6");
        });

        modelBuilder.Entity<PhanHoi>(entity =>
        {
            entity.HasKey(e => e.MaPhanHoi).HasName("PK__PhanHoi__3458D20FB4F8D8CD");

            entity.ToTable("PhanHoi");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.PhanHois)
                .HasForeignKey(d => d.MaKhachHang)
                .HasConstraintName("FK__PhanHoi__MaKhach__5BE2A6F2");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.PhanHois)
                .HasForeignKey(d => d.MaVe)
                .HasConstraintName("FK__PhanHoi__MaVe__5CD6CB2B");
        });

        modelBuilder.Entity<PhieuNhap>(entity =>
        {
            entity.HasKey(e => e.MaPhieuNhap).HasName("PK__PhieuNha__1470EF3B2486A81D");

            entity.ToTable("PhieuNhap");

            entity.Property(e => e.TongGiaTri).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TrangThai).HasMaxLength(50);

            entity.HasOne(d => d.MaDoiTacNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaDoiTac)
                .HasConstraintName("FK__PhieuNhap__MaDoi__4CA06362");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.PhieuNhaps)
                .HasForeignKey(d => d.MaNhanVien)
                .HasConstraintName("FK__PhieuNhap__MaNha__4D94879B");
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__TaiKhoan__AD7C65290111B8EC");

            entity.ToTable("TaiKhoan");

            entity.HasIndex(e => e.TenDangNhap, "UQ__TaiKhoan__55F68FC0E77A5FF0").IsUnique();

            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.QuyenTruyCap)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TenDangNhap)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ve>(entity =>
        {
            entity.HasKey(e => e.MaVe).HasName("PK__Ve__2725100FD3E064F5");

            entity.ToTable("Ve");

            entity.Property(e => e.GiaBan).HasColumnType("decimal(12, 2)");
            entity.Property(e => e.TenVe).HasMaxLength(100);

            entity.HasOne(d => d.MaDichVuNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.MaDichVu)
                .HasConstraintName("FK__Ve__MaDichVu__49C3F6B7");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
