using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Webpro.Models;

public partial class Select
{
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Datex { get; set; }

    public double? Payablebillwithdiscount { get; set; }

    public string? Chalanno { get; set; }

    public double? Discountpercent { get; set; }
}
