using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class GioHang
{
    public int IdGioHang { get; set; }

    public int? SoLuong { get; set; }

    public int? TongGiaTri { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<SanPham> IdSanPhams { get; set; } = new List<SanPham>();
}
