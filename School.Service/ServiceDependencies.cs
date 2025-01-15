using Microsoft.Extensions.DependencyInjection;
using School.Service.Abstract;
using School.Service.Implementation;
using School.Service.Services;

namespace School.Service
{
    public static class ServiceDependencies
    {
        public static IServiceCollection RegisterServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, Studentservice>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IDepartmentWithCountService, DepartmentWithCountService>();
            services.AddScoped<IDepartmentProc, DepartmentProc>();
            return services;
        }
    }
}
