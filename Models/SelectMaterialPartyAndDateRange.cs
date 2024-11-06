using System;
using System.Collections.Generic;

namespace Webpro.Models;

public partial class SelectMaterialPartyAndDateRange
{
    public DateTime? Datex { get; set; }

    public string? Chalanno { get; set; }

    public string? Partyname { get; set; }

    public string? Material { get; set; }

    public double? Qty { get; set; }

    public double? RateApplied { get; set; }

    public double? Bill { get; set; }
}
