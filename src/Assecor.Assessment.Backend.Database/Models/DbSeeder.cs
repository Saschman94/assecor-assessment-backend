using Assecor.Assessment.Backend.Modules.SharedDomain.Domain.Entities;
using Assecor.Assessment.Backend.SharedDomain.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Assecor.Assessment.Backend.Database.Models
{
    public static class DbSeeder
    {
        #region Methods

        #region Public Static Methods

        public static async Task SeedAsync(IServiceProvider services,CancellationToken ct = default)
        {
            using var scope = services.CreateScope();
            var sp = scope.ServiceProvider;

            var db = sp.GetRequiredService<PeopleDbContext>();

            await db.Database.MigrateAsync(ct);

            if (await db.Persons.AnyAsync(ct))
                return;

            var entities = PersonSeedData.People.Select(MapToEntity).ToList();

            await db.Persons.AddRangeAsync(entities, ct);
            await db.SaveChangesAsync(ct);
        }

        #endregion Public Static Methods

        #region Private Static Methods

        private static PersonEntity MapToEntity(Person p)
        {
            return new PersonEntity
            {
                Id = p.Id,
                Name = p.Name,
                LastName = p.LastName,
                PostalCode = p.Address.PostalCode.Value,
                City = p.Address.City,
                FavoriteColor = (int)p.FavoriteColor
            };
        }

        #endregion Private Static Methods

        #endregion Methods
    }

    public static class PersonSeedData
    {
        #region Properties

        public static IReadOnlyCollection<Person> People { get; } =
        [
        new Person(
            id: 1,
            name: "Hans",
            lastname: "Müller",
            address: new Address(new PostalCode("67742"), "Lauterecken"),
            favoriteColor: Color.Blue),

        new Person(
            id: 2,
            name: "Peter",
            lastname: "Petersen",
            address: new Address(new PostalCode("18439"), "Stralsund"),
            favoriteColor: Color.Green),

        new Person(
            id: 3,
            name: "Johnny",
            lastname: "Johnson",
            address: new Address(new PostalCode("88888"), "made up"),
            favoriteColor: Color.Purple),

        new Person(
            id: 4,
            name: "Milly",
            lastname: "Millenium",
            address: new Address(new PostalCode("77777"), "made up too"),
            favoriteColor: Color.Red),

        new Person(
            id: 5,
            name: "Jonas",
            lastname: "Müller",
            address: new Address(new PostalCode("32323"), "Hansstadt"),
            favoriteColor: Color.Yellow),

            new Person(
            id: 6,
            name: "Tastatur",
            lastname: "Fujitsu",
            address: new Address(new PostalCode("42342"), "Japan"),
            favoriteColor: Color.Turquoise),

        new Person(
            id: 7,
            name: "Anders",
            lastname: "Andersson",
            address: new Address(new PostalCode("32132"), "Schweden - â˜€"),
            favoriteColor: Color.Green),

        new Person(
            id: 8,
            name: "Gerda",
            lastname: "Gerber",
            address: new Address(new PostalCode("76535"), "Woanders"),
            favoriteColor: Color.Purple),

        new Person(
            id: 9,
            name: "Klaus",
            lastname: "Klaussen",
            address: new Address(new PostalCode("43246"), "Hierach"),
            favoriteColor: Color.Green),

    ];

        #endregion Properties
    }
}
