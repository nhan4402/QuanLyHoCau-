using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class TaiKhoan
{
    public int IdTaiKhoan { get; set; }

    public string? TaiKhoan1 { get; set; }

    public string? MatKhau { get; set; }

    public string? HoTen { get; set; }

    public string? Sðt { get; set; }

    public string? Email { get; set; }

    public string? DiaChi { get; set; }

    public string? Token { get; set; }

    public int RoleId { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();

    public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();

    public virtual Role Role { get; set; } = null!;
}
