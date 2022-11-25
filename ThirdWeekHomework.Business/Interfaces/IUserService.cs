using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThirdWeekHomework.Data.DTOs;
using ThirdWeekHomework.Domain.Entities;

namespace ThirdWeekHomework.Business.Interfaces
{
    public interface IUserService
    {
        void Add(UserDTO user);
        List<User> GetAllUsers();
    }
}
