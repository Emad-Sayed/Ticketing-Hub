﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Module.Shared.Application.Intefaces.UnitOfWork;
using Modules.Catalogs.Application.Commands.AddCatalog;
using Modules.Catalogs.Domain;
using Modules.Catalogs.Infrastructure;

namespace Module.Catalogs
{
    public static class CatalogModule
    {
        public static void AddCatalogServices(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<CatalogDomainService>();
            services.AddScoped<ICatalogRepository, CatalogRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<CatalogDbContext>(options => options.UseSqlServer(connectionString));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCatalogCommand).Assembly));

        }
    }
}
