using EmployeeDirectory.Models;
using EmployeeDirectory.Repository.Context;
using EmployeeDirectory.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Repository
{
    public class RoleRepository : IRepository<Role>
    {
        private readonly AppDbContext _context;


        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Role> Get()
        {
            return _context.Roles
                .Include(r => r.Location)
                .Include(r => r.Department)
                .ToList();
        }

        public Role Get(string id)
        {
            return _context.Roles
                .Include(r => r.Location)
                .Include(r => r.Department)
                .FirstOrDefault(r => r.Id == id)!;
        }

        public void Insert(Role data)
        {
            _context.Roles.Add(data);
            _context.SaveChanges();
        }

        public void Update(Role data)
        {
            _context.Entry(data).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool Delete(string id)
        {
            var role = _context.Roles.Find(id);
            if (role != null)
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
