using Assecor.Assessment.Backend.Modules.CSV.Application.Interfaces;
using Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Dispatcher;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Interfaces;
using Assecor.Assessment.Backend.Modules.CSV.Infrastructure.CSV;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Assecor.Assessment.Backend.Modules.CSV
{
    public static class CsvModule
    {
        #region Methods

        #region Public Static Methods

        public static IServiceCollection AddCsvModule (this IServiceCollection services, string csvFileLocation)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CsvModule).Assembly));
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
            services.AddScoped<IPersonRepository>(sp =>
            {
                var logger = sp.GetRequiredService<ILogger<CsvPersonRepository>>();

                return new CsvPersonRepository(csvFileLocation, logger);
            });

            return services;
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}
