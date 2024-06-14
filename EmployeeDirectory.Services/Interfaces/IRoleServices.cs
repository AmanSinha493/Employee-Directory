using EmployeeDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Interfaces
{
    public interface IRoleServices
    {
        public void Add(DTO.Role role, List<string> employeesToAssign);
        public List<DTO.Role> Get();
        public DTO.Role Get(string id);
        public Dictionary<string, string> GetRole();
        public DTO.Role GetRole(string name);
        public void Delete(string id);

        public List<DTO.Department> GetDepartments();
        public DTO.Department GetDepartments(string name);
        public List<DTO.Location> GetLocations();
        public DTO.Location GetLocations(string name);
    }
}
