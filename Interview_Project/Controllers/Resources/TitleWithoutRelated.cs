using System;

namespace Interview_Project.Controllers.Resources
{
    public class TitleWithoutRelated
    {
        public string TitleId { get; set; }
        public string Title1 { get; set; }
        public string Type { get; set; }
        public string PubId { get; set; }
        public decimal? Price { get; set; }
        public decimal? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSales { get; set; }
        public string Notes { get; set; }
        public DateTime Pubdate { get; set; }
    }
}