using Microsoft.Extensions.DependencyInjection;
using School.Data.Entities;
using School.Infrastructure.Abstract;
using School.Infrastructure.Repositories;

namespace School.Infrastructure
{
    public static class InfrastructurDependecies
    {
        public static IServiceCollection RegisterInfrastructuredependencies(this IServiceCollection services)
        {
            
            services.AddScoped<IStudentRepository,StudentRepository>();
            return services;
        }
    }
}
