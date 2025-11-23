using FastEndpoints;

namespace Assecor.Assessment.Backend.Api.Endpoints.Persons.GetPersonsByColor
{
    public class Request
    {
        #region Properties

        [BindFrom("id")]
        public int Id { get; set; }

        #endregion Properties
    }
}
