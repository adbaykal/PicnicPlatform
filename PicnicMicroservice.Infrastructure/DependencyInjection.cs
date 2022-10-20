using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PicnicMicroservice.Application.Common.Interfaces;
using PicnicMicroservice.Infrastructure.Persistence;
using PicnicMicroservice.Infrastructure.Services;

namespace PicnicMicroservice.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDBContext).Assembly.FullName)));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDBContext>());

            services.AddScoped<IDomainEventService, DomainEventService>();


            return services;
        }
    }
}
