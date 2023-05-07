using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace QuanLyHoCau_.Models;

public partial class QlhoCauContext : DbContext
{
    public QlhoCauContext()
    {
    }

    public QlhoCauContext(DbContextOptions<QlhoCauContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ca> Cas { get; set; }

    public virtual DbSet<DanhMucDichVu> DanhMucDichVus { get; set; }

    public virtual DbSet<DanhMucSanPham> DanhMucSanPhams { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<DichVuGioHang> DichVuGioHangs { get; set; }

    public virtual DbSet<GioHang> GioHangs { get; set; }

    public virtual DbSet<HoCau> HoCaus { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<LichHen> LichHens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<SanPham> SanPhams { get; set; }

    public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ca>(entity =>
        {
            entity.HasKey(e => e.TenCa).HasName("pk_Ca");

            entity.ToTable("Ca");

            entity.Property(e => e.TenCa).HasMaxLength(50);
            entity.Property(e => e.HinhAnh).HasColumnType("image");
            entity.Property(e => e.LoaiCa).HasMaxLength(50);
            entity.Property(e => e.MoTaCa).HasMaxLength(50);
        });

        modelBuilder.Entity<DanhMucDichVu>(entity =>
        {
            entity.HasKey(e => e.IdDanhSachDichVu).HasName("pk_DanhMucDichVu");

            entity.ToTable("DanhMucDichVu");

            entity.Property(e => e.IdDanhSachDichVu).ValueGeneratedNever();
            entity.Property(e => e.TenDanhSach).HasMaxLength(50);
        });

        modelBuilder.Entity<DanhMucSanPham>(entity =>
        {
            entity.HasKey(e => e.IdDanhSachSanPham).HasName("pk_DanhMucSanPham");

            entity.ToTable("DanhMucSanPham");

            entity.Property(e => e.IdDanhSachSanPham).ValueGeneratedNever();
            entity.Property(e => e.TenDanhSach).HasMaxLength(50);
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.IdDichVu).HasName("pk_DichVu");

            entity.ToTable("DichVu");

            entity.Property(e => e.IdDichVu).ValueGeneratedNever();
            entity.Property(e => e.MoTaDichVu).HasMaxLength(250);
            entity.Property(e => e.TenDichVu).HasMaxLength(50);

            entity.HasOne(d => d.IdDanhSachDichVuNavigation).WithMany(p => p.DichVus)
                .HasForeignKey(d => d.IdDanhSachDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DichVu__IdDanhSa__5629CD9C");
        });

        modelBuilder.Entity<DichVuGioHang>(entity =>
        {
            entity.HasKey(e => new { e.IdGioHang, e.IdDichVu }).HasName("pk_DichVu_GioHang");

            entity.ToTable("DichVu_GioHang");

            entity.HasOne(d => d.IdDichVuNavigation).WithMany(p => p.DichVuGioHangs)
                .HasForeignKey(d => d.IdDichVu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DichVu_Gi__IdDic__59063A47");
        });

        modelBuilder.Entity<GioHang>(entity =>
        {
            entity.HasKey(e => e.IdGioHang).HasName("pk_GioHang");

            entity.ToTable("GioHang");

            entity.Property(e => e.IdGioHang).ValueGeneratedNever();
        });

        modelBuilder.Entity<HoCau>(entity =>
        {
            entity.HasKey(e => e.IdHoCau).HasName("pk_HoCau");

            entity.ToTable("HoCau");

            entity.Property(e => e.IdHoCau).ValueGeneratedNever();
            entity.Property(e => e.DiaDiem).HasMaxLength(50);
            entity.Property(e => e.MoTaHoCau).HasMaxLength(250);
            entity.Property(e => e.TenHoCau).HasMaxLength(50);
            entity.Property(e => e.ThoiGianHoatDong).HasColumnType("datetime");

            entity.HasMany(d => d.TenCas).WithMany(p => p.IdHoCaus)
                .UsingEntity<Dictionary<string, object>>(
                    "HoCauCa",
                    r => r.HasOne<Ca>().WithMany()
                        .HasForeignKey("TenCa")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__HoCau_Ca__TenCa__619B8048"),
                    l => l.HasOne<HoCau>().WithMany()
                        .HasForeignKey("IdHoCau")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__HoCau_Ca__IdHoCa__5FB337D6"),
                    j =>
                    {
                        j.HasKey("IdHoCau", "TenCa").HasName("pk_HoCau_Ca");
                        j.ToTable("HoCau_Ca");
                        j.IndexerProperty<string>("TenCa").HasMaxLength(50);
                    });
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => new { e.IdHoaDon, e.IdTaiKhoan, e.IdGioHang }).HasName("pk_HoaDon");

            entity.ToTable("HoaDon");

            entity.Property(e => e.NgayTaoHoaDon).HasColumnType("datetime");
            entity.Property(e => e.TenHoaDon).HasMaxLength(50);

            entity.HasOne(d => d.IdGioHangNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdGioHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__HoaDon__IdGioHan__5DCAEF64");

            entity.HasOne(d => d.IdTaiKhoanNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.IdTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("thanh_toan");
        });

        modelBuilder.Entity<LichHen>(entity =>
        {
            entity.HasKey(e => new { e.IdLichHen, e.IdTaiKhoan, e.IdHoCau }).HasName("pk_LichHen");

            entity.ToTable("LichHen");

            entity.Property(e => e.NgayDatLichHen).HasColumnType("datetime");
            entity.Property(e => e.ThoiGianLichHen).HasColumnType("datetime");

            entity.HasOne(d => d.IdHoCauNavigation).WithMany(p => p.LichHens)
                .HasForeignKey(d => d.IdHoCau)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__LichHen__IdHoCau__60A75C0F");

            entity.HasOne(d => d.IdTaiKhoanNavigation).WithMany(p => p.LichHens)
                .HasForeignKey(d => d.IdTaiKhoan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("dat_lich_cau");

            entity.HasMany(d => d.IdDichVus).WithMany(p => p.Ids)
                .UsingEntity<Dictionary<string, object>>(
                    "LichHenDichVu",
                    r => r.HasOne<DichVu>().WithMany()
                        .HasForeignKey("IdDichVu")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LichHen_D__IdDic__571DF1D5"),
                    l => l.HasOne<LichHen>().WithMany()
                        .HasForeignKey("IdLichHen", "IdTaiKhoan", "IdHoCau")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__LichHen_DichVu__59FA5E80"),
                    j =>
                    {
                        j.HasKey("IdLichHen", "IdDichVu", "IdTaiKhoan", "IdHoCau").HasName("pk_LichHen_DichVu");
                        j.ToTable("LichHen_DichVu");
                    });
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("pk_Role");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnName("Role_Id");
            entity.Property(e => e.MoTaChucVu).HasMaxLength(255);
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .HasColumnName("Role_Name");
        });

        modelBuilder.Entity<SanPham>(entity =>
        {
            entity.HasKey(e => e.IdSanPham).HasName("pk_SanPham");

            entity.ToTable("SanPham");

            entity.Property(e => e.IdSanPham).ValueGeneratedNever();
            entity.Property(e => e.MoTaSanPham).HasMaxLength(250);
            entity.Property(e => e.TenSanPham).HasMaxLength(50);

            entity.HasOne(d => d.IdDanhSachSanPhamNavigation).WithMany(p => p.SanPhams)
                .HasForeignKey(d => d.IdDanhSachSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SanPham__IdDanhS__5CD6CB2B");

            entity.HasMany(d => d.IdDichVus).WithMany(p => p.IdSanPhams)
                .UsingEntity<Dictionary<string, object>>(
                    "SanPhamDichVu",
                    r => r.HasOne<DichVu>().WithMany()
                        .HasForeignKey("IdDichVu")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__SanPham_D__IdDic__5812160E"),
                    l => l.HasOne<SanPham>().WithMany()
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("CoTrong"),
                    j =>
                    {
                        j.HasKey("IdSanPham", "IdDichVu").HasName("pk_SanPham_DichVu");
                        j.ToTable("SanPham_DichVu");
                    });

            entity.HasMany(d => d.IdGioHangs).WithMany(p => p.IdSanPhams)
                .UsingEntity<Dictionary<string, object>>(
                    "SanPhamGioHang",
                    r => r.HasOne<GioHang>().WithMany()
                        .HasForeignKey("IdGioHang")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__San-Pham___IdGio__5EBF139D"),
                    l => l.HasOne<SanPham>().WithMany()
                        .HasForeignKey("IdSanPham")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__San-Pham___IdSan__5BE2A6F2"),
                    j =>
                    {
                        j.HasKey("IdSanPham", "IdGioHang").HasName("pk_San-Pham_GioHang");
                        j.ToTable("San-Pham_GioHang");
                    });
        });

        modelBuilder.Entity<TaiKhoan>(entity =>
        {
            entity.HasKey(e => e.IdTaiKhoan).HasName("pk_TaiKhoan");

            entity.ToTable("TaiKhoan");

            entity.Property(e => e.IdTaiKhoan).ValueGeneratedNever();
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.RoleId).HasColumnName("Role_Id");
            entity.Property(e => e.Sðt)
                .HasMaxLength(50)
                .HasColumnName("SÐT");
            entity.Property(e => e.TaiKhoan1)
                .HasMaxLength(50)
                .HasColumnName("TaiKhoan");
            entity.Property(e => e.Token).HasMaxLength(255);

            entity.HasOne(d => d.Role).WithMany(p => p.TaiKhoans)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaiKhoan__Role_I__628FA481");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-6I4J93P;Database=QLHoCau");
    }
}
