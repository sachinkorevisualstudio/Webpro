using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; // For DisplayFormat attribute
using System.ComponentModel.DataAnnotations.Schema; // For Column and other attributes related to database schema

namespace Webpro.Models;

public partial class TblDispatch
{
    public int Id { get; set; }

    /// <summary>
    /// nvchar 10 null
    /// </summary>
    public string? Chalanno { get; set; }

    /// <summary>
    /// nvchar 10 null
    /// </summary>
    public string RegOrStock { get; set; } = null!;

    /// <summary>
    /// date
    /// </summary>
    [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? Datex { get; set; }

    /// <summary>
    /// nvchar 10 null
    /// </summary>
    public string? Timex { get; set; }

    /// <summary>
    /// month name january to december according to datex nvchar 15 null
    /// </summary>
    public string? Monthnamex { get; set; }

    /// <summary>
    /// year 2022 to 2050 according to datex nvarchar 4
    /// </summary>
    public string? Yearnamex { get; set; }

    /// <summary>
    /// dropdown select partyname from tblpartynamelist nvarchar 25
    /// </summary>
    public string? Partyname { get; set; }

    /// <summary>
    /// if faund partyname in tblpartynamelist then show in      nvarchar 25   dropdownlist else show as rokh_general
    /// </summary>
    public string? Txtpartynamesearched { get; set; }

    /// <summary>
    /// site name nvarchar 25
    /// </summary>
    public string? Site { get; set; }

    /// <summary>
    /// comboxbox nv-10
    /// </summary>
    public string? Vehicleno { get; set; }

    /// <summary>
    /// populate drivername if vehicleno found in tblvehiclenumbers  nv-15
    /// </summary>
    public string? Drivername { get; set; }

    /// <summary>
    /// optional nv-25
    /// </summary>
    public string? Supervisorname { get; set; }

    /// <summary>
    ///   select material combobox nv25
    /// </summary>
    public string? Material { get; set; }

    /// <summary>
    /// nv-3
    /// </summary>
    public string? Trip { get; set; }

    /// <summary>
    /// optional numeric 10,3
    /// </summary>
    public double? Ton { get; set; }

    /// <summary>
    /// quantity in bras n5-3
    /// </summary>
    public double? Qty { get; set; }

    /// <summary>
    /// auto rate n7-2
    /// </summary>
    public double? RateFromchart { get; set; }

    /// <summary>
    /// if vehicleno n7-2 faund in tblvehiclenumbers then show alert add transport charge
    /// </summary>
    public double? TransportCharge { get; set; }

    /// <summary>
    /// rate applied = transport_charge + rate_from chart
    /// </summary>
    public double? RateApplied { get; set; }

    /// <summary>
    /// amount1 =qty *rate_applied
    /// </summary>
    public double Amount1 { get; set; }

    /// <summary>
    /// Yes,No combobox
    /// </summary>
    public string? Gstcustomer { get; set; }

    /// <summary>
    /// 5% gst     cgst sgst included
    /// </summary>
    public double? GstAmount { get; set; }

    /// <summary>
    /// recievedamount  or amount paid by customer
    /// </summary>
    public double TotalAmountBill { get; set; }

    /// <summary>
    /// 10% on purebill qty *ratechart
    /// </summary>
    public double? Discountpercent { get; set; }

    /// <summary>
    /// optional
    /// </summary>
    public double? Royalty { get; set; }

    /// <summary>
    /// bill after discount
    /// </summary>
    public double? Payablebillwithdiscount { get; set; }

    /// <summary>
    /// rokh wale
    /// </summary>
    public double? CashPaymentRs { get; set; }

    /// <summary>
    /// rokh wale
    /// </summary>
    public double? OnlinePaymentRs { get; set; }

    /// <summary>
    /// anything remember details
    /// </summary>
    public string? Summary { get; set; }

    /// <summary>
    /// non gst/gst customer jama amount
    /// </summary>
    public double? JamaAmt { get; set; }

    /// <summary>
    /// month of  to 1 to 12 according datex
    /// </summary>
    public short? Monthnumber { get; set; }

    /// <summary>
    /// current date and time now
    /// </summary>
    public DateTime? DataEntryDatetime { get; set; }= DateTime.Now;
}
