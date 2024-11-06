namespace Webpro.Models
{
    public class RateChartViewModel
    {
        public string Partyname { get; set; } = null!;  // Use non-nullable reference types
        public string Material { get; set; } = null!;
        public double? RateFromChart { get; set; }
    }
}
