using System.Collections.Generic;

namespace Interview_Project.Controllers.Resources
{
    public class PublisherResource
    {
        public PublisherResource()
        {
            Employees = new HashSet<EmployeeResource>();
            // Titles = new HashSet<Title>();
        }

        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        // public virtual PubInfo PubInfo { get; set; }
        public virtual ICollection<EmployeeResource> Employees { get; set; }
        // public virtual ICollection<Title> Titles { get; set; }    }
    }
}