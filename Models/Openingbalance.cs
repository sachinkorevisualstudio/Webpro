using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webpro.Models;

public partial class Openingbalance
{
    public int Id { get; set; }

    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Datex { get; set; }

    public string? Partyname { get; set; }

    public double? Openingbal { get; set; }

   
}
