using EmployeeDirectory.Models;
using EmployeeDirectory.Repository.Context;
using EmployeeDirectory.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        private readonly AppDbContext _context;

        public DepartmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Department> Get()
        {
            return _context.Departments.ToList();
        }

        public Department Get(string id)
        {
            return _context.Departments.FirstOrDefault(d => d.Id == id)!;
        }

        public void Insert(Department data)
        {
            throw new NotImplementedException();
        }

        public void Update(Department data)
        {
            throw new NotImplementedException();
        }
    }
}
