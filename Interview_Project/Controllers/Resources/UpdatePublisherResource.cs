using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Interview_Project.Controllers.Resources
{
    public class UpdatePublisherResource : IValidatableObject
    {
        [MaxLength(40)] [Required] public string PubName { get; set; }
        [MaxLength(20)] [Required] public string City { get; set; }
        [MaxLength(2)] public string State { get; set; }

        [MaxLength(30)] [Required] public string Country { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (string.IsNullOrWhiteSpace(PubName))
                yield return new ValidationResult("PubName cannot be empty");
            if (string.IsNullOrWhiteSpace(City))
                yield return new ValidationResult("City cannot be empty");
            if (string.IsNullOrWhiteSpace(Country))
                yield return new ValidationResult("Country cannot be empty");
        }
    }
}