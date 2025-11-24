using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using FluentResults;
using MediatR;

namespace Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Commands
{
    public record GetAllPersonsCommand() : IRequest<Result<IReadOnlyCollection<Person>>>;
}
