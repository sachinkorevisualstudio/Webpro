using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // For DisplayFormat attribute
using System.ComponentModel.DataAnnotations.Schema; // For Column and other attributes related to database schema

namespace Webpro.Models;

public partial class Note
{
    public int Id { get; set; }
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Datex { get; set; }

    public string? Note1 { get; set; }
}
