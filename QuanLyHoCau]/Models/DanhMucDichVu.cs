using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class DanhMucDichVu
{
    public int IdDanhSachDichVu { get; set; }

    public string? TenDanhSach { get; set; }

    public virtual ICollection<DichVu> DichVus { get; set; } = new List<DichVu>();
}
