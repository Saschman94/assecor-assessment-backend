using Assecor.Assessment.Backend.API.Tests.TestBase;
using Assecor.Assessment.Backend.SharedDomain.Application.Interfaces;
using Assecor.Assessment.Backend.SharedDomain.Application.Messaging.Commands;
using Assecor.Assessment.Backend.SharedDomain.Domain.Entities;
using AutoFixture.AutoNSubstitute;
using FluentResults;
using Microsoft.AspNetCore.Http;
using NSubstitute;
using Shouldly;
using Xunit;
using Endpoint = Assecor.Assessment.Backend.Api.Endpoints.Persons.GetPersons.Endpoint;

namespace Assecor.Assessment.Backend.API.Tests.Endpoints.Persons
{
    public class GetPersonsEndpointTests
    {
        #region Methods

        #region Public Methods

        [Theory, PersonEndpointsAutoData]
        public async Task HandleAsync_Success_Returns_Fail_Returns_Failure([Substitute] ICommandDispatcher testCommandDispatcher)
        {
            // Arrange
            testCommandDispatcher.Dispatch(Arg.Any<GetAllPersonsCommand>(), Arg.Any<CancellationToken>()).Returns(Result.Fail("Person not found"));
            var httpContext = new DefaultHttpContext();
            var testEndpoint = FastEndpoints.Factory.Create<Endpoint>(httpContext, testCommandDispatcher);

            // Act
            await testEndpoint.HandleAsync(new(), default);

            // Assert
            httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status404NotFound);
            await testCommandDispatcher.Received(1).Dispatch(Arg.Any<GetAllPersonsCommand>(), Arg.Any<CancellationToken>());
        }

        [Theory, PersonEndpointsAutoData]
        public async Task HandleAsync_Success_Returns_Fail_Returns_Ok(List<Person> persons, [Substitute] ICommandDispatcher testCommandDispatcher)
        {
            // Arrange
            testCommandDispatcher.Dispatch(Arg.Any<GetAllPersonsCommand>(), Arg.Any<CancellationToken>()).Returns(persons);
            var httpContext = new DefaultHttpContext();
            var testEndpoint = FastEndpoints.Factory.Create<Endpoint>(httpContext, testCommandDispatcher);

            // Act
            await testEndpoint.HandleAsync(new(), default);

            // Assert
            httpContext.Response.StatusCode.ShouldBe(StatusCodes.Status200OK);
            await testCommandDispatcher.Received(1).Dispatch(Arg.Any<GetAllPersonsCommand>(), Arg.Any<CancellationToken>());
        }

        #endregion Public Methods

        #endregion Methods
    }
}
