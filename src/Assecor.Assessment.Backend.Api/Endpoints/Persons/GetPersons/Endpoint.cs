using Assecor.Assessment.Backend.Api.Endpoints.Persons.Mappers;
using Assecor.Assessment.Backend.Api.Endpoints.Persons.Reponses;
using Assecor.Assessment.Backend.SharedDomain.Application.Interfaces;
using Assecor.Assessment.Backend.SharedDomain.Application.Messaging.Commands;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;

namespace Assecor.Assessment.Backend.Api.Endpoints.Persons.GetPersons
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

            if (result.IsFailed)
            {
                await Send.NotFoundAsync(cancellation: ct);
            }
            else
            {
                await Send.OkAsync(PersonResponseMapper.MapToPersonsResponse(result.Value), cancellation: ct);
            }
        }

        #endregion Public Methods

        #endregion Methods
    }
}
