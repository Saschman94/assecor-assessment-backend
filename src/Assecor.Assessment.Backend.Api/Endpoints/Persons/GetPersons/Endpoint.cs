using Assecor.Assessment.Backend.Modules.CSV.Application.Interfaces;
using Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Commands;
using assecor_assessment_backend.Endpoints.Persons.Mappers;
using assecor_assessment_backend.Endpoints.Persons.Reponses;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace assecor_assessment_backend.Endpoints.Persons.GetPersons
{
    [HttpGet("/persons")]
    [AllowAnonymous]
    public class Endpoint(ICommandDispatcher dispatcher) : EndpointWithoutRequest<PersonsResponse>
    {
        #region Fields

        private readonly ICommandDispatcher _dispatcher = dispatcher;

        #endregion Fields

        #region Methods

        #region Public Methods

        public override async Task HandleAsync(CancellationToken ct)
        {
            var result = await _dispatcher.Dispatch(new GetAllPersonsCommand(), ct);

            var response = PersonResponseMapper.MapToPersonsResponse(result);

            await Send.OkAsync(response, cancellation: ct);
        }

        #endregion Public Methods

        #endregion Methods
    }
}
