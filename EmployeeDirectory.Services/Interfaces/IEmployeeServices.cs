using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Interfaces
{
    public interface IEmployeeServices
    {
        public void Add(DTO.Employee employee);
        public List<DTO.Employee> Get();
        public void Delete(string id);
        public void Edit(DTO.Employee employee);
        public DTO.Employee Get(string id);

        public List<string> GetEmployeeIds();
        public bool CheckEmployee(string id);
        public void Update(DTO.Employee employee);
        public List<DTO.Project> GetProjects();
        public DTO.Project GetProject(string name);
    }
}
