using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Entities;
using Contracts;
using Repository;

namespace phone_book_api.Extensions 
{
    public static class ServiceExtensions 
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy("CorsPolicy",
                    // builder => builder.WithOrigins("http://localhost:4200/")
                    //     .WithMethods("GET", "POST")
                    builder => builder.AllowAnyOrigin()
                        .WithMethods("GET", "POST")    
                        .AllowAnyHeader()
                        .AllowCredentials());
            });
        }

        public static void ConfigureIISIntergration(this IServiceCollection services) {
            services.Configure<IISOptions>(options => {
                //leave options as default 
                //i.e. AutomaticAuthentication=true
                //AuthenticationDisplayName=null
                //ForwardClientCertificate=true
            });
        }

        public static void ConfigureMySqlContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["mysqlconnection:connectionString"];
            services.AddDbContext<RepositoryContext>(o => o.UseMySql(connectionString));
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}