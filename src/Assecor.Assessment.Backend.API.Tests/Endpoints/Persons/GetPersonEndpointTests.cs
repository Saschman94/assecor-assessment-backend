using Assecor.Assessment.Backend.API.Tests.TestBase;
using Assecor.Assessment.Backend.Modules.CSV.Application.Interfaces;
using Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Commands;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using AutoFixture.AutoNSubstitute;
using FluentResults;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Shouldly;
using Xunit;
using Endpoint = Assecor.Assessment.Backend.Api.Endpoints.Persons.GetPerson.Endpoint;
using Request = Assecor.Assessment.Backend.Api.Endpoints.Persons.GetPerson.Request;

namespace Assecor.Assessment.Backend.API.Tests.Endpoints.Persons
{
    public class GetPersonEndpointTests
    {
        #region Methods

        #region Public Methods

        [Theory, PersonEndpointsAutoData]
        public async Task HandleAsync_Failure_Returns_Failure(Request request, [Substitute] ICommandDispatcher testCommandDispatcher)
        {
            // Arrange
            testCommandDispatcher.Dispatch(Arg.Is<GetPersonCommand>(c => c.Id == request.Id), Arg.Any<CancellationToken>()).Returns(Result.Fail<Person>("Person not found"));
            var httpContext = new DefaultHttpContext();
            var testEndpoint = FastEndpoints.Factory.Create<Endpoint>(httpContext, testCommandDispatcher);

            // Act
            await testEndpoint.HandleAsync(request, default);

            // Assert
            httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
            await testCommandDispatcher.Received(1).Dispatch(Arg.Is<GetPersonCommand>(c => c.Id == request.Id), Arg.Any<CancellationToken>());
        }

        [Theory, PersonEndpointsAutoData]
        public async Task HandleAsync_Success_Returns_Ok(Request request, Person testPerson, [Substitute] ICommandDispatcher testCommandDispatcher)
        {
            // Arrange
            testCommandDispatcher.Dispatch(Arg.Is<GetPersonCommand>(c => c.Id == request.Id), Arg.Any<CancellationToken>()).Returns(Result.Ok(testPerson));
            var httpContext = new DefaultHttpContext();
            var testEndpoint = FastEndpoints.Factory.Create<Endpoint>(httpContext, testCommandDispatcher);

            // Act
            await testEndpoint.HandleAsync(request, default);

            // Assert
            httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status200OK);
            await testCommandDispatcher.Received(1).Dispatch(Arg.Is<GetPersonCommand>(c => c.Id == request.Id), Arg.Any<CancellationToken>());
        }

        #endregion Public Methods

        #endregion Methods
    }
}
