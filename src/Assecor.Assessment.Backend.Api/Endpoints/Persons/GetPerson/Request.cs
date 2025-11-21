using FastEndpoints;

namespace assecor_assessment_backend.Endpoints.Persons.GetPerson
{
    public class Request
    {
        #region Properties

        [BindFrom("id")]
        public int Id { get; set; }

        #endregion Properties
    }
}
