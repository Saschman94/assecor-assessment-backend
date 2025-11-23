using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using MediatR;

namespace Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Commands
{
    public record GetPersonCommand(int Id) : IRequest<Person>;
}
