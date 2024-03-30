using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.DAL;
using Server.Repositories;
using Server.Services;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using Server.Contants;
using Server.DTO;
using System.Data;

namespace Server.Config
{
    public class Config
    {
        static IServiceProvider _serviceProvider;

        public static void Register(HttpConfiguration config)
        {
            // New code
            config.EnableSystemDiagnosticsTracing();
            // Other configuration code not shown.
        }
        public static void InitServiceProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public static T GetInstance<T>()
        {
            return _serviceProvider.GetService<T>();
        }

        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            // set up migration and connectdb
            services.AddDbContext<DatabaseContext>((sp, opt) =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IDbConnection>(ww => DbFactory.GetDbConnection(configuration.GetConnectionString("DefaultConnection")));

            // set redis
            var redisSettings = configuration.GetSection(Keys.RedisSettings).Get<RedisDTO>();
            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = redisSettings.Host + ":" + redisSettings.Port + ",connectTimeout=10000,syncTimeout=10000";
            });


            // DJ service
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBetService, BetService>();

            // DJ repository
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBetRepository, BetRepository>();

        }
    }
}