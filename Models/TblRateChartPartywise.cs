using System;
using System.Collections.Generic;

namespace Webpro.Models;

public partial class TblRateChartPartywise
{
    public int Indexnum { get; set; }

    /// <summary>
    /// name or company name
    /// </summary>
    public string Partyname { get; set; } = null!;

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? RateGsb { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? RateWmm { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? Rate60mm { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? Rate40mm { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? Rate26mm { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? Rate20mm { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? Rate10mm { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? Rate8by6 { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? RateMsand { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? RateDust { get; set; }

    /// <summary>
    /// WASHABLE SAND
    /// </summary>
    public double? RateWsand { get; set; }

    /// <summary>
    /// WASHABLE PLASTER SAND    OR PSAND
    /// </summary>
    public double? RateWpsand { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? RateStone { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? RateRoboSand { get; set; }

    /// <summary>
    /// DEFAULT VALUE
    /// </summary>
    public double? RateSander { get; set; }
}
