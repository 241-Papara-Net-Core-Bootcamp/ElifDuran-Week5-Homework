using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdWeekHomework.Business.Interfaces;
using ThirdWeekHomework.Data.DTOs;
using ThirdWeekHomework.Data.Interfaces;
using ThirdWeekHomework.Domain.Entities;

namespace ThirdWeekHomework.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> repository;
        private readonly ICacheService cacheService;
        private const string cacheKey = "UserCacheKey"; //Unique key
        private readonly IMapper mapper;

        public UserService(IRepository<User> _repository, ICacheService _cacheService, IMapper _mapper)
        {
            repository = _repository;
            cacheService = _cacheService;
            mapper = _mapper;
        }
        public void Add(UserDTO userDTO)
        {
            var user = mapper.Map<User>(userDTO);
            var cachedList = repository.Add(user);
            //refresh cache 
            cacheService.Remove(cacheKey);
            cacheService.Set(cacheKey, cachedList);
        }

        public List<User> GetAllUsers()
        {
            var userList = repository.GetAll().ToList();
            cacheService.Set(cacheKey, userList);                   // Cache the user list 
            cacheService.TryGet<User>(cacheKey, out userList);       // Get cached user list     
            return userList;
        }
    }
}
