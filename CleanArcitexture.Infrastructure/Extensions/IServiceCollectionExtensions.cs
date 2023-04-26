using CleanArcitexture.Application.Interfaces;
using CleanArcitexture.Domain.Common;
using CleanArcitexture.Domain.Common.Interfaces;


using MediatR;

using Microsoft.Extensions.DependencyInjection;

namespace CleanArcitexture.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services)
        {
            services.AddServices();
        }
        private static void AddServices(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
                
        }
    }
}
