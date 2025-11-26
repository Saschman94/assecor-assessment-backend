using Assecor.Assessment.Backend.Modules.SharedDomain.Domain.Interfaces;
using Assecor.Assessment.Backend.SharedDomain.Application.Messaging.Commands;
using Assecor.Assessment.Backend.SharedDomain.Domain.Entities;
using FluentResults;
using MediatR;

namespace Assecor.Assessment.Backend.SharedDomain.Application.Messaging.Handlers
{
    public class GetPersonHandler : IRequestHandler<GetPersonCommand, Result<Person>>
    {
        #region Constructors

        public GetPersonHandler(IPersonRepository repository)
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

        public async Task<Result<Person>> Handle(GetPersonCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var person = await _repository.GetPersonByIdAsync(request.Id, cancellationToken);

                if (person is null)
                    return Result.Fail("No person with given ID found.");

                return Result.Ok(person);
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
