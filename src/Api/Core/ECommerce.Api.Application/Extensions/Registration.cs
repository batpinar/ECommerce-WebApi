using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Api.Application.Extensions
{
    public static class Registration
    {
        public static IServiceCollection AddApplicationRegistration(this IServiceCollection services)
        {
            var assmbl = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(assmbl);
            services.AddMediatR(assmbl);
            services.AddValidatorsFromAssembly(assmbl);

            return services;
        }
    }
}
