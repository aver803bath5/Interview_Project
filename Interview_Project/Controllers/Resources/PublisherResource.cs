using System.Collections.Generic;

namespace Interview_Project.Controllers.Resources
{
    public class PublisherResource
    {
        public PublisherResource()
        {
            Employees = new HashSet<EmployeeWithoutRelatedResource>();
            Titles = new HashSet<TitleWithoutRelated>();
        }

        public string PubId { get; set; }
        public string PubName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public virtual PubInfoWithoutRelative PubInfo { get; set; }
        public virtual ICollection<EmployeeWithoutRelatedResource> Employees { get; set; }
        public virtual ICollection<TitleWithoutRelated> Titles { get; set; }
    }
}