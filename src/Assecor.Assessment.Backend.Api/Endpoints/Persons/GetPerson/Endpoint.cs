using Assecor.Assessment.Backend.Api.Endpoints.Persons.Reponses;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Assecor.Assessment.Backend.Api.Endpoints.Persons.GetPerson
{
    [HttpGet("/persons/{id}")]
    [AllowAnonymous]
    public class Endpoint : Endpoint<Request, PersonResponse>
    {
        #region Methods

        #region Public Methods

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            // Implementation goes here
            await Send.OkAsync(new PersonResponse(), cancellation: ct);
        }

        #endregion Public Methods

        #endregion Methods
    }
}
