﻿using Project.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Interfaces
{
    public interface IRequestRepository<T>
    {
        Task<List<T>> GetAllRequestsAsync();
        Task<List<T>> GetByCategoryAsync(string category);
        Task<List<T>> GetByUserIdAsync(int userId);
        Task<T> AddAsync(T item);
        Task<T> UpdateAsync(int id, T item);
        Task<T> DeleteByIdAsync(int id);
    }
}
