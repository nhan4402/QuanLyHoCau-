using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class Ca
{
    public string TenCa { get; set; } = null!;

    public string? LoaiCa { get; set; }

    public string? MoTaCa { get; set; }

    public byte[]? HinhAnh { get; set; }

    public virtual ICollection<HoCau> IdHoCaus { get; set; } = new List<HoCau>();
}
