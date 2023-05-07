using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class SanPham
{
    public int IdSanPham { get; set; }

    public string? TenSanPham { get; set; }

    public int? GiaSanPham { get; set; }

    public string? MoTaSanPham { get; set; }

    public int IdDanhSachSanPham { get; set; }

    public virtual DanhMucSanPham IdDanhSachSanPhamNavigation { get; set; } = null!;

    public virtual ICollection<DichVu> IdDichVus { get; set; } = new List<DichVu>();

    public virtual ICollection<GioHang> IdGioHangs { get; set; } = new List<GioHang>();
}
