using Assecor.Assessment.Backend.Api.Endpoints.Persons.Mappers;
using Assecor.Assessment.Backend.Api.Endpoints.Persons.Reponses;
using Assecor.Assessment.Backend.Modules.CSV.Application.Interfaces;
using Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;

namespace Assecor.Assessment.Backend.Api.Endpoints.Persons.GetPerson
{
    [HttpGet("/persons/{id}")]
    [AllowAnonymous]
    public class Endpoint(ICommandDispatcher dispatcher) : Endpoint<Request, PersonResponse>
    {
        #region Fields

        private readonly ICommandDispatcher _dispatcher = dispatcher;

        #endregion Fields

        #region Methods

        #region Public Methods

        public override async Task HandleAsync(Request req, CancellationToken ct)
        {
            var result = await _dispatcher.Dispatch(new GetPersonCommand(req.Id), ct);

            var response = PersonResponseMapper.MapToPersonResponse(result);

            await Send.OkAsync(response, cancellation: ct);
        }

        #endregion Public Methods

        #endregion Methods
    }
}
