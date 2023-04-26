using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CleanArcitexture.Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
       public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddMediatR();
            services.AddValidators();
        }
        private static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
        private static void AddMediatR(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
        private static void AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
