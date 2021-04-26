using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Interview_Project.Controllers.Resources
{
    public class SavePublisherResource  : IValidatableObject
    {
        [Required]
        public string PubId { get; set; }
        [MaxLength(40)]
        public string PubName { get; set; }
        [MaxLength(20)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(30)]
        [DefaultValue(PublisherConstraints.DefaultCountryName)]
        public string Country { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var reg = new Regex(PublisherConstraints.PudIdPattern);
            if (!reg.IsMatch(PubId))
            {
                yield return new ValidationResult("PubId is not match the pattern.");
            }
        }
    }
}