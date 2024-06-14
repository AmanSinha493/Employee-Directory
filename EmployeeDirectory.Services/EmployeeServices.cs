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
    public class EmployeeServices : IEmployeeServices
    {

        IRepository<Models.Employee>? employeeRepo;
        IRepository<Project> projectRepo;
        IMapper mapper;
        public EmployeeServices(IRepository<Models.Employee> employeeRepo, IRepository<Project> projectRepo, IMapper mapper)
        {
            this.employeeRepo = employeeRepo;
            this.projectRepo = projectRepo;
            this.mapper = mapper;
        }
        public void Add(DTO.Employee employee)
        {
            Employee newEmployee = mapper.Map<Employee>(employee);
            newEmployee.Id = GenerateId();
            employeeRepo.Insert(newEmployee);

        }
        public void Delete(string id)
        {
            employeeRepo.Delete(id);
        }

        public DTO.Employee Get(string id)
        {
            return mapper.Map<DTO.Employee>(employeeRepo.Get().FirstOrDefault(e => e.Id == id));
        }
        public List<DTO.Project> GetProjects()
        {
            return mapper.Map<List<DTO.Project>>(projectRepo.Get());
        }
        public DTO.Project GetProject(string name)
        {
            Project project = projectRepo.Get().Where(p => p.Name == name).FirstOrDefault();
            return mapper.Map<DTO.Project>(project);
        }
        public List<DTO.Employee> Get()
        {
            return mapper.Map<List<DTO.Employee>>(employeeRepo.Get());
        }
        public bool CheckEmployee(string id)
        {
            List<string> employeeIds = GetEmployeeIds();
            return employeeIds.Contains(id);
        }
        public List<string> GetEmployeeIds()
        {
            List<Models.Employee> employeesList = employeeRepo.Get();
            return employeesList.Select(e => e.Id).ToList();
        }
        public void Edit(DTO.Employee employee)
        {
            employeeRepo.Update(mapper.Map<Employee>(employee));
        }

        public void Update(DTO.Employee employee)
        {
            employeeRepo.Update(mapper.Map<Employee>(employee));
        }

        public string GenerateId()
        {
            List<string> employeeIds = GetEmployeeIds();
            string lastId = employeeIds.Last();
            string prefix = "TZ";
            string numericPart = lastId.Substring(prefix.Length);

            if (int.TryParse(numericPart, out int numericId))
            {

                int newNumericId = numericId + 1;
                string newId = prefix + newNumericId.ToString("D4");
                return newId;
            }
            else
            {
                throw new ArgumentException("Invalid role ID format.");
            }
        }
    }
}
