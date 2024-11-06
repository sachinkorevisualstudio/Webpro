using System;
using System.Collections.Generic;

namespace Webpro.Models;

public partial class TblVehicleNumber
{
    public int Id { get; set; }

    public string? CompanyVehicleNumber { get; set; }

    public string? DriverNameOptional { get; set; }

    public string? WeightCapacity { get; set; }
}
