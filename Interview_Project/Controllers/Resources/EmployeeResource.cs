using System;

namespace Interview_Project.Controllers.Resources
{
    public class EmployeeResource
    {
        public int Id { get; set; }
        public string EmpId { get; set; }
        public string Fname { get; set; }
        public string Minit { get; set; }
        public string Lname { get; set; }
        public short JobId { get; set; }
        public byte JobLvl { get; set; }
        public string PubId { get; set; }
        public DateTime HireDate { get; set; }
        
        public virtual JobWithoutRelatedResource Job { get; set; }
        public virtual PublisherWithoutRelatedResource Pub { get; set; }
    }
}