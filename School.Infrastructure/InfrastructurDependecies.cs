using Microsoft.Extensions.DependencyInjection;
using School.Infrastructure.Abstract;
using School.Infrastructure.Repositories;

namespace School.Infrastructure
{
    public static class InfrastructurDependecies
    {
        public static IServiceCollection RegisterInfrastructuredependencies(this IServiceCollection services)
        {

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            return services;
        }
    }
}
