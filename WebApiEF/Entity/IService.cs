using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEF.Models;

namespace WebApiEF.Entity
{
    public interface IService
    {
        Task<StateResponse<IEnumerable<UserModel>>> GetAllAsync();
        Task<StateResponse<UserModel>> GetAsync(int id);
        Task<StateResponse<bool>> DeleteAsync(int id);
        Task<StateResponse<UserModel>> CreateAsync(UserModel user);
        Task<StateResponse<UserModel>> UpdateAsync(int id, UserModel user);
    }
}
