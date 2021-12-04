using Business.Concrete;
using Business.Interface;
using DataAccess.Contexts;
using DataAccess.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Microsoft
{
    public static class StartupExtensions
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });
            services.AddScoped<IWorkService, WorkManager>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
