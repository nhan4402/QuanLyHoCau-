using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class HoCau
{
    public int IdHoCau { get; set; }

    public string TenHoCau { get; set; } = null!;

    public string? DiaDiem { get; set; }

    public DateTime? ThoiGianHoatDong { get; set; }

    public int? SoLuongCho { get; set; }

    public int? SoLuongCa { get; set; }

    public string? MoTaHoCau { get; set; }

    public virtual ICollection<LichHen> LichHens { get; set; } = new List<LichHen>();

    public virtual ICollection<Ca> TenCas { get; set; } = new List<Ca>();
}
