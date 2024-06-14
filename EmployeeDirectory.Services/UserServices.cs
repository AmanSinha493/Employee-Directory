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
    public class UserServices : IUserServices
    {
        private readonly IRepository<User> _userRepo;
        private readonly IMapper _mapper;
        public UserServices(IRepository<User> userRepository, IMapper mapper)
        {
            _userRepo = userRepository;
            _mapper = mapper;
        }
        public DTO.UserLogin Get(string id)
        {
            return _mapper.Map<DTO.UserLogin>(_userRepo.Get(id));
        }
        public List<DTO.User> Get()
        {
            return _mapper.Map<List<DTO.User>>(_userRepo.Get());
        }
        public void Add(DTO.User user)
        {
            User newUser = _mapper.Map<User>(user);
            _userRepo.Insert(newUser);

        }
    }
}
