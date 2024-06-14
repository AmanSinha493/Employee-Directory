using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Repository.Interfaces
{
    public interface IRepository<T>
    {
        public List<T> Get();
        public T Get(string id);
        public void Update(T data);
        public void Insert(T data);
        public bool Delete(string id);
    }
}
