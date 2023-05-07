using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class HoaDon
{
    public int IdHoaDon { get; set; }

    public string? TenHoaDon { get; set; }

    public DateTime? NgayTaoHoaDon { get; set; }

    public int? TongTienDaThanhToan { get; set; }

    public int IdTaiKhoan { get; set; }

    public int IdGioHang { get; set; }

    public virtual GioHang IdGioHangNavigation { get; set; } = null!;

    public virtual TaiKhoan IdTaiKhoanNavigation { get; set; } = null!;
}
