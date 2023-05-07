using System;
using System.Collections.Generic;

namespace QuanLyHoCau_.Models;

public partial class LichHen
{
    public int IdLichHen { get; set; }

    public DateTime? NgayDatLichHen { get; set; }

    public DateTime? ThoiGianLichHen { get; set; }

    public int IdTaiKhoan { get; set; }

    public int IdHoCau { get; set; }

    public virtual HoCau IdHoCauNavigation { get; set; } = null!;

    public virtual TaiKhoan IdTaiKhoanNavigation { get; set; } = null!;

    public virtual ICollection<DichVu> IdDichVus { get; set; } = new List<DichVu>();
}
