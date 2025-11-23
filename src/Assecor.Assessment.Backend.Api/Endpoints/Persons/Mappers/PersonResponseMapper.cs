using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using assecor_assessment_backend.Endpoints.Persons.Reponses;

namespace assecor_assessment_backend.Endpoints.Persons.Mappers
{
    public static class PersonResponseMapper
    {
        #region Methods

        #region Public Static Methods

        public static PersonResponse MapToPersonResponse(Person person) => new PersonResponse
        {
            Id = person.Id,
            Name = person.Name,
            LastName = person.LastName,
            Zipcode = person.Address.PostalCode.Value,
            City = person.Address.City,
            Color = MapColor(person.FavoriteColor)
        };

        public static PersonsResponse MapToPersonsResponse(IEnumerable<Person> persons) => new PersonsResponse
        {
            Persons = [.. persons.Select(MapToPersonResponse)]
        };

        #endregion Public Static Methods

        #region Private Static Methods

        private static string MapColor(Color color) => color switch
        {
            Color.Unknown => "unbekannt",
            Color.Blue => "blau",
            Color.Green => "grün",
            Color.Purple => "violet",
            Color.Red => "red",
            Color.Yellow => "gelb",
            Color.Turquoise => "türkis",
            Color.White => "weiß",
            _ => "unbekannt"
        };

        #endregion Private Static Methods

        #endregion Methods
    }
}
