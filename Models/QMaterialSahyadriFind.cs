using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webpro.Models;

public partial class QMaterialSahyadriFind
{
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Datex { get; set; }

    public string? Monthnamex { get; set; }

    public string? Yearnamex { get; set; }

    public string? Partyname { get; set; }

    public string? Material { get; set; }

    public double? _6 { get; set; }

    public double? RateFromchart { get; set; }
}
