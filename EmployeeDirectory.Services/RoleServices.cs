using AutoMapper;
using EmployeeDirectory.Models;
using EmployeeDirectory.Repository.Interfaces;
using EmployeeDirectory.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services
{
    public class RoleServices : IRoleServices
    {

        readonly IRepository<Role>? roleRepo;
        readonly IEmployeeServices employeeServices;
        readonly IRepository<Department> deptRepo;
        readonly IRepository<Location> locRepo;
        readonly IMapper mapper;

        public RoleServices(IEmployeeServices employeeServices, IRepository<Role> roleRepo, IRepository<Department> deptRepo, IRepository<Location> locRepo, IMapper mapper)
        {
            this.employeeServices = employeeServices;
            this.roleRepo = roleRepo;
            this.deptRepo = deptRepo;
            this.locRepo = locRepo;
            this.mapper = mapper;
        }
        public string GenerateRoleId()
        {
            List<Role> roles = roleRepo.Get();
            return $"R00{roles.Count + 1}";
        }
        public void Add(DTO.Role role, List<string> employeesToAssign)
        {
            role.Id = GenerateRoleId();
            roleRepo!.Insert(mapper.Map<Role>(role));
            List<Employee> employeesList = new List<Employee>();

            //foreach (Employee employee in employeesList)
            //{
            //    if (employeesToAssign.Contains(employee.Id!))
            //    {
            //        employee.RoleId = role.Id;
            //        employeeServices.Update(employee);
            //    }
            //}
        }

        public List<DTO.Role> Get()
        {
            List<DTO.Role> RoleList = mapper.Map<List<DTO.Role>>(roleRepo.Get());
            return RoleList;
        }

        public DTO.Role Get(string id)
        {
            return mapper.Map<DTO.Role>(roleRepo!.Get(id));
        }
        public DTO.Role GetRole(string name)
        {
            Role role = roleRepo!.Get().Where(r => r.Name == name).FirstOrDefault();
            return mapper.Map<DTO.Role>(role);
        }

        public Dictionary<string, string> GetRole()
        {
            List<Role> roleList = roleRepo.Get();
            Dictionary<string, string> roles = roleList.ToDictionary(r => r.Name!, r => r.Id!);
            return roles!;
        }

        public void Delete(string id)
        {
            roleRepo.Delete(id);
        }
        public List<DTO.Department> GetDepartments()
        {
            return mapper.Map<List<DTO.Department>>(deptRepo!.Get());
        }
        public DTO.Department GetDepartments(string id)
        {
            return mapper.Map<DTO.Department>(deptRepo!.Get(id));
        }
        public DTO.Location GetLocations(string id)
        {
            return mapper.Map<DTO.Location>(locRepo!.Get(id));
        }
        public List<DTO.Location> GetLocations()
        {
            return mapper.Map<List<DTO.Location>>(locRepo!.Get());
        }

        
    }
}
