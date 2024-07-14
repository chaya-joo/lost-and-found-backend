using Microsoft.Extensions.DependencyInjection;
using Project.Common.Dto;
using Project.Repository;
using Project.Service.Interfaces;
using Project.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Service
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepository();
            services.AddScoped<IItemService<ItemDto>, ItemService>();
            services.AddScoped<IRequestService<RequestDto>, RequestService>();
            services.AddScoped<IUserService<UserDto>, UserService>();
            services.AddScoped<ISendEmailService,SendEmailService>();
            services.AddScoped<IGetPasswordService, GetNewPassword>();
            services.AddAutoMapper(typeof(MapProFile));
            return services;
        }
    }
}
