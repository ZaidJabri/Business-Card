using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Interfaces;
using API.Repositories;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();

            services.AddDbContext<DataContext>(options =>
             options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped<IBusinessCardService, BusinessCardService>();
            services.AddScoped<IBusinessCardRepository, BusinessCardRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}