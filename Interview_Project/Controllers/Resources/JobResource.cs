using System.Collections.Generic;

namespace Interview_Project.Controllers.Resources
{
    public class JobResource
    {
        public JobResource()
        {
            Employees = new HashSet<EmployeeWithoutRelatedResource>();
        }

        public short JobId { get; set; }
        public string JobDesc { get; set; }
        public byte MinLvl { get; set; }
        public byte MaxLvl { get; set; }

        public virtual ICollection<EmployeeWithoutRelatedResource> Employees { get; set; }
    }
}