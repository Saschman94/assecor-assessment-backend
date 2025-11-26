using Assecor.Assessment.Backend.SharedDomain.Domain.Entities;
using FluentResults;
using MediatR;

namespace Assecor.Assessment.Backend.SharedDomain.Application.Messaging.Commands
{
    public record GetPersonCommand(int Id) : IRequest<Result<Person>>;
}
