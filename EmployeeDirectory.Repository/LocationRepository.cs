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
    public class LocationRepository : IRepository<Location>
    {
        private readonly AppDbContext _context;

        public LocationRepository(AppDbContext context)
        {
            _context = context;
        }

        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }

        public List<Location> Get()
        {
            return _context.Locations.ToList();
        }

        public Location Get(string id)
        {
            return _context.Locations.FirstOrDefault(l => l.Id == id)!;

        }

        public void Insert(Location data)
        {
            throw new NotImplementedException();
        }

        public void Update(Location data)
        {
            throw new NotImplementedException();
        }
    }
}
