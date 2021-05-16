using Boozewasher.Application.Interfaces.CacheRepositories;
using Boozewasher.Application.Interfaces.Contexts;
using Boozewasher.Application.Interfaces.Repositories;
using Boozewasher.Infrastructure.CacheRepositories;
using Boozewasher.Infrastructure.DbContexts;
using Boozewasher.Infrastructure.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Boozewasher.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            #region Repositories

            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCacheRepository, ProductCacheRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<IBrandCacheRepository, BrandCacheRepository>();
            services.AddTransient<IBranchRepository, BranchRepository>();
            services.AddTransient<IBranchCacheRepository, BranchCacheRepository>();
            services.AddTransient<ILogRepository, LogRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion Repositories
        }
    }
}