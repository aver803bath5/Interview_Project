using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Interview_Project.Controllers.Resources
{
    public class UpdatePublisherResource
    {
        [MaxLength(40)] [Required] public string PubName { get; set; }
        [MaxLength(20)] [Required] public string City { get; set; }
        [MaxLength(2)] public string State { get; set; }

        [MaxLength(30)] [Required] public string Country { get; set; }
    }
}