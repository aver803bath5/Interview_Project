using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Interview_Project.Controllers.Resources
{
    public class AddEmployeeResource
    {
        [Required]
        [MaxLength(9)]
        [RegularExpression(EmployeeConstraint.EmpIdPattern)]
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
        public byte JobLvl { get; set; }
        [Required]
        public string PubId { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
    }
}