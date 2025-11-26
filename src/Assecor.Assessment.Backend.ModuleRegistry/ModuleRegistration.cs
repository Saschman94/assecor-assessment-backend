using Assecor.Assessment.Backend.Database;
using Assecor.Assessment.Backend.Modules.CSV;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Assecor.Assessment.Backend.ModuleRegistry
{
    public static class ModuleRegistration
    {
        #region Methods

        #region Public Static Methods

        public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            var csvFileLocation = configuration.GetSection("CsvModule:FileLocation").Value;
            var dbConnectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ModuleRegistration).Assembly));

            if (!string.IsNullOrWhiteSpace(dbConnectionString))
            {
                services.AddDbModule(dbConnectionString);
                return services;
            }

            if (string.IsNullOrWhiteSpace(csvFileLocation))
                throw new ArgumentNullException(csvFileLocation, "CSV file location is not configured properly.");

            services.AddCsvModule(csvFileLocation);

            return services;
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}
