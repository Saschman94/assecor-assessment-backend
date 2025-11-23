namespace Assecor.Assessment.Backend.Api.Endpoints.Persons.Reponses
{
    public class PersonsResponse
    {
        #region Properties

        public IReadOnlyCollection<PersonResponse> Persons { get; set; } = [];

        #endregion Properties
    }
}
