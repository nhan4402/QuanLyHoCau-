using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class DichVu
{
    public int IdDichVu { get; set; }

    public string? TenDichVu { get; set; }

    public int? GiaDichVu { get; set; }

    public string? MoTaDichVu { get; set; }

    public int IdDanhSachDichVu { get; set; }

    public virtual ICollection<DichVuGioHang> DichVuGioHangs { get; set; } = new List<DichVuGioHang>();

    public virtual DanhMucDichVu IdDanhSachDichVuNavigation { get; set; } = null!;

    public virtual ICollection<SanPham> IdSanPhams { get; set; } = new List<SanPham>();

    public virtual ICollection<LichHen> Ids { get; set; } = new List<LichHen>();
}
