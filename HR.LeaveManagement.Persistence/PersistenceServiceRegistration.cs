﻿
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Persistence.DatabseContext;
using HR.LeaveManagement.Persistence.DatabseContext.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HR.LeaveManagement.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServiceRegistration(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<HrDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("HrDatabaseConnectionString"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        return services;
    }
}
