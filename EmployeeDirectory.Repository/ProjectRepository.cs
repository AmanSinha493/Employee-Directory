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
    public class ProjectRepository : IRepository<Project>
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Project> Get()
        {
            return _context.Projects.ToList();
        }

        public Project Get(string id)
        {
            return _context.Projects.FirstOrDefault(p => p.Id == id)!;

        }

        public void Insert(Project data)
        {
            throw new NotImplementedException();
        }

        public void Update(Project data)
        {
            throw new NotImplementedException();
        }
    }
}
