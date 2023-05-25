using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CarRentalz.Datas.Repository;
using CarRentalz.Datas.Repository.Contract;

namespace CarRentalz.Application.IoC
{
    public static class IoCApplication
    {
        public static IServiceCollection ConfigureInjectionDependencyRepository(this IServiceCollection services)
        {
            services.AddScoped<IVerificationRepository, VerificationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRatingRepository, UserRatingRepository>();
            services.AddScoped<ITypeEnumRepository, TypeEnumRepository>();
            services.AddScoped<IRentRepository, RentRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IGearboxEnumRepository, GearboxEnumRepository>();
            services.AddScoped<IFuelEnumRepository, FuelEnumRepository>();
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<ICarSettingRepository, CarSettingRepository>();
            services.AddScoped<ICarRatingRepository, CarRatingRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IAgencyRepository, AgencyRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAdminGradeRepository, AdminGradeRepository>();

            return services;

        }


        /// <summary>
        /// Configure l'injection des services
        /// </summary>
        /// <param name="services">The services.</param>
        /// <returns></returns>
        public static IServiceCollection ConfigureInjectionDependencyService(this IServiceCollection services)
        {
            // Injections des Dépendances
            // - Service

            //services.AddScoped<IServiceDepartement, ServiceDepartement>();

            //return services;
        }

        /// <summary>
        /// Configuration de la connexion de la base de données
        /// </summary>
        /// <param name="services"></param>
        public static IServiceCollection ConfigureDBContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("BddConnection");

            //services.AddDbContext<IMeteoContext, MeteoDBContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
            //    .LogTo(Console.WriteLine, LogLevel.Information)
            //    .EnableSensitiveDataLogging()
            //    .EnableDetailedErrors());

            //return services;
        }

    }
}

