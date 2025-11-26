using Assecor.Assessment.Backend.Database.Db;
using Assecor.Assessment.Backend.Database.Models;
using Assecor.Assessment.Backend.Modules.SharedDomain.Domain.Interfaces;
using Assecor.Assessment.Backend.SharedDomain.Application.Interfaces;
using Assecor.Assessment.Backend.SharedDomain.Application.Messaging.Dispatcher;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assecor.Assessment.Backend.Database
{
    public static class DbModule
    {
        #region Methods

        #region Public Static Methods

        public static IServiceCollection AddDbModule(this IServiceCollection services, string connectionString)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DbModule).Assembly));
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();

            services.AddDbContext<PeopleDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IPersonRepository, DbPersonRepository>();

            return services;
        }

        #endregion Public Static Methods

        #endregion Methods
    }
}
