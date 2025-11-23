using Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Commands;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Interfaces;
using MediatR;

namespace Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Handlers
{
    internal class GetPersonHandler : IRequestHandler<GetPersonCommand, Person>
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

        public async Task<Person> Handle(GetPersonCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPersonByIdAsync(request.Id, cancellationToken);

            return result;
        }

        #endregion Public Methods

        #endregion Methods
    }
}
