using System;
using System.Collections.Generic;

namespace Webpro.Models;

public partial class Partysummry
{
    public string? Chalanno { get; set; }

    public DateTime? Datex { get; set; }

    public string? Partyname { get; set; }

    public string? Vehicleno { get; set; }

    public string? Material { get; set; }

    public double? Qty { get; set; }

    public double? RateFromchart { get; set; }

    public double? TransportCharge { get; set; }

    public double? RateApplied { get; set; }

    public double? Payablebillwithdiscount { get; set; }
}
