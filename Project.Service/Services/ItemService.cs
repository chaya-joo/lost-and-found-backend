﻿using AutoMapper;
using Project.Common.Dto;
using Project.Repository.Entities;
using Project.Repository.Interfaces;
using Project.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service.Services
{
    public class ItemService : IItemService<ItemDto>
    {

        private readonly IItemRepository<Item> repository;
        private readonly IRequestRepository<Request> repository2;
        private readonly IUserRepository<User> repository3;
        ISendEmailService emailService;
        private readonly IMapper mapper;
        public ItemService(IItemRepository<Item> repository, IRequestRepository<Request> repository2, IUserRepository<User> repository3, ISendEmailService emailService, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.repository2 = repository2;
            this.repository3 = repository3;
            this.emailService = emailService;
        }

        public async Task<List<ItemDto>> GetAllItemsAsync()
        {
            return await mapper.Map<Task<List<ItemDto>>>(repository.GetAllItemsAsync());
        }

        public async Task<ItemDto> AddAsync(ItemDto itemDto)
        {
            List<RequestDto> s = mapper.Map<List<RequestDto>>(repository2.GetByCategoryAsync(itemDto.Category).Result.ToList());
            foreach (RequestDto item in s)
            {
                UserDto user = await mapper.Map<Task<UserDto>>(repository3.GetByIdAsync(item.UserId));
                if (user.Id != itemDto.UserId)
                    emailService.SendEmail(user.Email, user.Name, $"Hello {user.Name}\nadd a new item from the category", $"added a new item from category");
            }
            await repository.AddAsync(mapper.Map<Item>(itemDto));
            return itemDto;
        }

        public async Task<ItemDto> DeleteByIdAsync(int id)
        {
            var item = await repository.DeleteByIdAsync(id);
            return mapper.Map<ItemDto>(item);
        }

        public async Task<List<ItemDto>> GetByCategoryAsync(string category)
        {
            return await mapper.Map<Task<List<ItemDto>>>(mapper.Map<Task<List<Item>>>(repository.GetByCategoryAsync(category)));
        }

        public async Task<List<ItemDto>> GetByUserIdAsync(int userId)
        {
            return await mapper.Map<Task<List<ItemDto>>>(mapper.Map<Task<List<Item>>>(repository.GetByUserIdAsync(userId)));
        }

        public async Task<ItemDto> UpdateAsync(int id, ItemDto item)
        {
            var itemDto = await repository.UpdateAsync(id, mapper.Map<Item>(item));
            return mapper.Map<ItemDto>(itemDto);
        }

    }
}