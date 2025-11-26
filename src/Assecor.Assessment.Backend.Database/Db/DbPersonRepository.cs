using Assecor.Assessment.Backend.Database.Models;
using Assecor.Assessment.Backend.Modules.SharedDomain.Domain.Entities;
using Assecor.Assessment.Backend.Modules.SharedDomain.Domain.Interfaces;
using Assecor.Assessment.Backend.SharedDomain.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assecor.Assessment.Backend.Database.Db
{
    internal class DbPersonRepository : IPersonRepository
    {
        #region Constructors

        public DbPersonRepository(PeopleDbContext peopleDbContext)
        {
            _peopleDbContext = peopleDbContext;
        }

        #endregion Constructors

        #region Fields

        private readonly PeopleDbContext _peopleDbContext;

        #endregion Fields

        #region Methods

        #region Private Static Methods

        private static Person MapToDomain(PersonEntity e)
        {
            var postalCode = new PostalCode(e.PostalCode);
            var address = new Address(postalCode, e.City);
            var color = (Color)e.FavoriteColor;

            return new Person(e.Id, e.Name, e.LastName, address, color);
        }

        #endregion Private Static Methods

        #region Public Methods

        public async Task<List<Person>> GetAllPersonsAsync(CancellationToken cancellationToken = default)
        {
            var entities = await _peopleDbContext.Persons.AsNoTracking().ToListAsync(cancellationToken);

            return [.. entities.Select(MapToDomain)];
        }

        public async Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _peopleDbContext.Persons.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id, cancellationToken);

            return entity is null ? null : MapToDomain(entity);
        }

        public async Task<List<Person>> GetPersonsByColorAsync(int id, CancellationToken cancellationToken = default)
        {
            var entities = await _peopleDbContext.Persons.AsNoTracking().Where(p => p.FavoriteColor == id).ToListAsync(cancellationToken);

            return [.. entities.Select(MapToDomain)];
        }

        #endregion Public Methods

        #endregion Methods
    }
}
