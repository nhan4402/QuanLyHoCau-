using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class DichVuGioHang
{
    public int IdGioHang { get; set; }

    public int IdDichVu { get; set; }

    public virtual DichVu IdDichVuNavigation { get; set; } = null!;
}
