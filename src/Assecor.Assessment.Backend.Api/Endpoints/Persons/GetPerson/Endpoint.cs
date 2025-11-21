using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace assecor_assessment_backend.Endpoints.Persons.GetPerson
{
    [HttpGet("/persons/{id}")]
    [AllowAnonymous]
    public class Endpoint : Endpoint<Request, Response>
    {
        #region Methods

        #region Public Methods

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            // Implementation goes here
            await Send.OkAsync(new Response(), cancellation: ct);
        }

        #endregion Public Methods

        #endregion Methods
    }
}
