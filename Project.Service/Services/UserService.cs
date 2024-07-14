﻿using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Repository.Entities;
using Project.Repository.Interfaces;
using Project.Common.Dto;
using AutoMapper;

namespace Project.Service.Services
{
    public class UserService:IUserService<UserDto>
    {
        private readonly IUserRepository<User> repository;
        private readonly IMapper mapper;
        public UserService(IUserRepository<User> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<UserDto> AddAsync(UserDto userDto)
        {
            await repository.AddAsync(mapper.Map<User>(userDto));
            return userDto;
        }
        public async Task<UserDto> DeleteByIdAsync(int id)
        {
           var user= await repository.DeleteByIdAsync(id); 
            return mapper.Map<UserDto>(user);
        }

        public async Task<List<UserDetails>> GetAllUsersDetailsAsync()
        {
            return await mapper.Map<Task<List<UserDetails>>>(mapper.Map<Task<List<User>>>(repository.GetAllUsersAsync()));
        }
        public async Task<List<UserDto>> GetAllUsersAsync()
        {
            return await mapper.Map<Task<List<UserDto>>>(mapper.Map<Task<List<User>>>(repository.GetAllUsersAsync()));
        }
        public async Task<UserDto> GetByIdAsync(int id)
        {
            
            return await mapper.Map<Task<UserDto>>(mapper.Map<Task<User>>(repository.GetByIdAsync(id)));
        }

        public async Task<UserDto> UpdateAsync(int id, UserDto userDto)
        {
            await repository.UpdateAsync(id, mapper.Map<User>(userDto));
            return userDto;
        }
    }
}
