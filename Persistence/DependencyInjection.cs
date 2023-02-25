using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence
{
   public static class DependencyInjection
    {
        public static IServiceCollection AddPersisteceDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            //configure DB
            services.AddDbContext<ApplicationDbContext>(
                 m => m.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            //For User & Auth optional requirement
            //// For Identity
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    .AddDefaultTokenProviders();
            return services;
        }
    }
}