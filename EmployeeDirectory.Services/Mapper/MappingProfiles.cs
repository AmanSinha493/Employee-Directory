using AutoMapper;
using EmployeeDirectory.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EmployeeDirectory.Services.Mapper
{
    public class MappingProfiles : Profile
    {
        private readonly IRoleServices _roleService;
        private readonly IEmployeeServices _empService;
        public MappingProfiles(IRoleServices roleService, IEmployeeServices empService)
        {
            _roleService = roleService;
            _empService = empService;
        }

        public MappingProfiles()
        {
            CreateMap<Models.User, DTO.UserLogin>();
            CreateMap<DTO.UserLogin, Models.User>();

            CreateMap<Models.Location, DTO.Location>();
            CreateMap<DTO.Location, Models.Location>();
            CreateMap<Models.Department, DTO.Department>();
            CreateMap<DTO.Department, Models.Department>();
            CreateMap<Models.Project, DTO.Project>();
            CreateMap<DTO.Project, Models.Project>();
            CreateMap<Models.User, DTO.User>();
            CreateMap<DTO.User, Models.User>();
            CreateMap<Models.Employee, DTO.Employee>()
           .ForMember(dest => dest.Name, act => act.MapFrom(src => src.FName + " " + src.LName))
                .ForMember(dest => dest.Role, act => act.MapFrom(src => src.Role.Name))
                .ForMember(dest => dest.location, act => act.MapFrom(src => new DTO.Location
                {
                    Id = src.Role.LocationId,
                    Name = src.Role.Location.Name
                }))
                .ForMember(dest => dest.Department, act => act.MapFrom(src => new DTO.Department
                {
                    Id = src.Role.DepartmentId,
                    Name = src.Role.Department.Name
                }))
                .ForMember(dest => dest.Project, act => act.MapFrom(src => new DTO.Project { Name = src.Project.Name, Id = src.Project.Id }));


            CreateMap<DTO.Employee, Models.Employee>()
           .ForMember(dest => dest.FName, act => act.MapFrom(src => GetFirstName(src.Name)))
           .ForMember(dest => dest.FName, act => act.MapFrom(src => GetFirstName(src.Name)))
           .ForMember(dest => dest.LName, act => act.MapFrom(src => GetLastName(src.Name)))
           .ForMember(dest => dest.Role, act => act.MapFrom(src => _roleService.Get(src.RoleID)))
            //.ForMember(dest => dest.Project, act => act.MapFrom(src => new DTO.Project { Name = src.Project.Name, Id = src.Project.Id }));
            .ForMember(dest => dest.Project, act => act.MapFrom(src => _empService.GetProject(src.Project.Id)));

            CreateMap<Models.Role, DTO.Role>()
               .ForMember(dest => dest.location, act => act.MapFrom(src => new DTO.Location
               {
                   Id = src.LocationId,
                   Name = src.Location.Name
               }))
               .ForMember(dest => dest.department, act => act.MapFrom(src => new DTO.Department
               {
                   Id = src.DepartmentId,
                   Name = src.Department.Name
               }));


            CreateMap<DTO.Role, Models.Role>()
                .ForMember(dest => dest.DepartmentId, act => act.MapFrom(src => src.department.Id))
                .ForMember(dest => dest.LocationId, act => act.MapFrom(src => src.location.Id))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => _roleService.GetDepartments(src.department.Id)))
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => _roleService.GetLocations(src.location.Id)));

        }

        private string GetFirstName(string fullName)
        {
            return fullName?.Split(' ')[0] ?? string.Empty;
        }
        private string GetLastName(string fullName)
        {
            return fullName?.Split(' ')[1] ?? string.Empty;
        }
    }
}
