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
    public class UserRepository : IRepository<User>
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<User> Get()
        {
            return _context.UserCredentials.ToList();
        }

        public User Get(string user)
        {
            throw new NotImplementedException();
        }

        public void Insert(User data)
        {
            _context.UserCredentials.Add(data);
            _context.SaveChanges();
        }

        public void Update(User data)
        {
            throw new NotImplementedException();
        }
    }
}
