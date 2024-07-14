using Project.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Interfaces
{
    public interface IUserService<T>
    {
        Task<List<UserDetails>> GetAllUsersDetailsAsync();
        Task<List<T>> GetAllUsersAsync();
        Task<T> GetByIdAsync(int id);//התחברות
        Task<T> AddAsync(T item);//הרשמה
        Task<T> UpdateAsync(int id, T item);//התחברות
        Task<T> DeleteByIdAsync(int id);//התחברות
    }
}
