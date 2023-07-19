using API.Data;
using API.interfaces;
using API.services;
using Microsoft.EntityFrameworkCore;

namespace API.Extenstions
{
    public static class ApplicationServiceExtenstions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config){
            services.AddDbContext<DataContext>(opt =>
            {
                opt.UseSqlite(config.GetConnectionString("DefaultConnection")); 
            }
            );
            services.AddCors();

            /*If we provide an interface over here we also have to provide the implmentation class 
            as well 
            The advantage of using an interface is when testing our codes */
            services.AddScoped<ITokenService, TokenServices>();

            return services;
        }
    }
}