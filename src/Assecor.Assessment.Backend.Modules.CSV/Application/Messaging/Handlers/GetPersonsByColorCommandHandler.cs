using Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Commands;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Interfaces;
using MediatR;

namespace Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Handlers
{
    internal class GetPersonsByColorCommandHandler : IRequestHandler<GetPersonsByColorCommand, IReadOnlyCollection<Person>>
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

        public async Task<IReadOnlyCollection<Person>> Handle(GetPersonsByColorCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetPersonsByColorAsync(request.Id, cancellationToken);

            return result;
        }

        #endregion Public Methods

        #endregion Methods
    }
}
