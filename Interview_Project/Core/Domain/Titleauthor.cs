#nullable disable

namespace Interview_Project.Core.Domain
{
    public partial class Titleauthor
    {
        public string AuId { get; set; }
        public string TitleId { get; set; }
        public byte? AuOrd { get; set; }
        public int? Royaltyper { get; set; }

        public virtual Author Au { get; set; }
        public virtual Title Title { get; set; }
    }
}
