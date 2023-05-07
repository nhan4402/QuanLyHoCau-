using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class DanhMucSanPham
{
    public int IdDanhSachSanPham { get; set; }

    public string? TenDanhSach { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
