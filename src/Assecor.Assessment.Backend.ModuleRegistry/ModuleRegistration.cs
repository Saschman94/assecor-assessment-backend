using Assecor.Assessment.Backend.Modules.CSV;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.ModuleRegistry
{
    public static class ModuleRegistration
    {
        #region Methods

        #region Public Static Methods

        public static IServiceCollection AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            var csvFileLocation = configuration.GetSection("CsvModule:FileLocation").Value;

            if(string.IsNullOrWhiteSpace(csvFileLocation))
                throw new ArgumentNullException(csvFileLocation, "CSV file location is not configured properly.");

            services.AddCsvModule(csvFileLocation);
            return services;
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}
