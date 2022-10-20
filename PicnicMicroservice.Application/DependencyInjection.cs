using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PicnicMicroservice.Application.Common.Interfaces;
using System.Reflection;

namespace PicnicMicroservice.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
