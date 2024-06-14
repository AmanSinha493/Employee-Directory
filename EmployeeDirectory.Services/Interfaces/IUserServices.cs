using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Services.Interfaces
{
    public interface IUserServices
    {
        public DTO.UserLogin Get(string id);
        public List<DTO.User> Get();
        public void Add(DTO.User user);
    }
}
