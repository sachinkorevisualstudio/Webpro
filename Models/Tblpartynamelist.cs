using System;
using System.Collections.Generic;

namespace Webpro.Models;

public partial class Tblpartynamelist
{
    /// <summary>
    /// name or company name
    /// </summary>
    public string Partyname { get; set; } = null!;

    /// <summary>
    /// Yes No
    /// </summary>
    public string GstCustomer { get; set; } = null!;

    public double? Transcharge { get; set; }

    public short? Discount { get; set; }
}
