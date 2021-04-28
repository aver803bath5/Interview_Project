using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Interview_Project.Controllers.Resources
{
    public class AddEmployeeResource : IValidatableObject
    {
        [Required]
        [MaxLength(9)]
        public string EmpId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Fname { get; set; }
        [MaxLength(1)]
        public string Minit { get; set; }
        [Required]
        [MaxLength(30)]
        public string Lname { get; set; }
        [Required]
        public short JobId { get; set; }
        [Required]
        public byte? JobLvl { get; set; }
        [Required]
        public string PubId { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var reg = new Regex(EmployeeConstraint.EmpIdPattern);
            if (!reg.IsMatch(EmpId))
                yield return new ValidationResult("EmpId does not match the pattern");
        }
    }
}