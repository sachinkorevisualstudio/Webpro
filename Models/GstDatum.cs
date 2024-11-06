using System;
using System.Collections.Generic;

namespace Webpro.Models;

public partial class GstDatum
{
    public string? Chalanno { get; set; }

    public DateTime? Datex { get; set; }

    public string? Monthnamex { get; set; }

    public string? Yearnamex { get; set; }

    public string? Partyname { get; set; }

    public string? Site { get; set; }

    public string? Vehicleno { get; set; }

    public string? Drivername { get; set; }

    public string? Material { get; set; }

    public double? Qty { get; set; }

    public double? RateApplied { get; set; }

    public double Amount1 { get; set; }

    public double? GstAmount { get; set; }

    public double? Payablebillwithdiscount { get; set; }
}
