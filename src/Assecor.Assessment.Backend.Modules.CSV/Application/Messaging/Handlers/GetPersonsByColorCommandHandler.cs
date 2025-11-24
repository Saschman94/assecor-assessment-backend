using Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Commands;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Interfaces;
using FluentResults;
using MediatR;

namespace Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Handlers
{
    internal class GetPersonsByColorCommandHandler : IRequestHandler<GetPersonsByColorCommand, Result<IReadOnlyCollection<Person>>>
    {
        #region Constructors

        public GetPersonsByColorCommandHandler(IPersonRepository repository)
        {
            ArgumentNullException.ThrowIfNull(repository);

            _repository = repository;
        }

        #endregion Constructors

        #region Fields

        private readonly IPersonRepository _repository;

        #endregion Fields

        #region Methods

        #region Public Methods

        public async Task<Result<IReadOnlyCollection<Person>>> Handle(GetPersonsByColorCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var persons = await _repository.GetPersonsByColorAsync(request.Id, cancellationToken);

                if (persons is null || persons.Count == 0)
                    return Result.Fail("No persons found.");

                return Result.Ok<IReadOnlyCollection<Person>>(persons);
            }
            catch (OperationCanceledException)
            {
                return Result.Fail(new Error("Request was cancelled."));
            }
            catch (Exception ex)
            {
                return Result.Fail(new Error("Unexpected error while loading person.").CausedBy(ex));
            }
        }

        #endregion Public Methods

        #endregion Methods
    }
}
