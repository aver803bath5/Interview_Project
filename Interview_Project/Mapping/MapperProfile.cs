using AutoMapper;
using Interview_Project.Controllers.Resources;
using Interview_Project.Core.Domain;

namespace Interview_Project.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Job, JobResource>();
            CreateMap<Employee, EmployeeResource>();

            CreateMap<JobResource, Job>();
            CreateMap<SaveJobResource, Job>()
                .ForMember(j => j.JobId, opt => opt.Ignore());
        }
    }
}