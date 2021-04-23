namespace Interview_Project.Controllers.Resources
{
    public class SaveJobResource
    {
        public short JobId { get; set; }
        public string JobDesc { get; set; }
        public byte MinLvl { get; set; }
        public byte MaxLvl { get; set; }
    }
}