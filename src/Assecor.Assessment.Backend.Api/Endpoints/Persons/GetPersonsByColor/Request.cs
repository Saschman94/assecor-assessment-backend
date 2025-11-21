using FastEndpoints;

namespace assecor_assessment_backend.Endpoints.Persons.GetPersonsByColor
{
    public class Request
    {
        [BindFrom("id")]
        public int Id { get; set; }
    }
}
