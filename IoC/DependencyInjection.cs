using Business_Logic_Layer.Services;
using Business_Logic_Layer.Services.IServices;
using Business_Logic_Layer.Utilities.AutoMapperProfiles;
using Data_Access_Layer.Data;
using Data_Access_Layer.Entities;
using Data_Access_Layer.Repositories;
using Data_Access_Layer.Repositories.IRepositories;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC
{
    public static class DependencyInjection
    {
        public static void InjectDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<MeetupDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableSensitiveDataLogging();
            });

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                    .AddIdentityServerAuthentication(options =>
                    {
                        options.Authority = "https://localhost:5443";
                        options.ApiName = "meetupApi";
                    });

            services.AddAutoMapper(cfg => cfg.AddProfile<AutoMapperProfiles>());

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventRepository<Event>, EventRepository>();
        }
    }
}
