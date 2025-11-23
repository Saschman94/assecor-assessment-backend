using FastEndpoints;

namespace Assecor.Assessment.Backend.Api.Endpoints.Persons.GetPerson
{
    public class Request
    {
        #region Properties

        [BindFrom("id")]
        public int Id { get; set; }

        #endregion Properties
    }
}
