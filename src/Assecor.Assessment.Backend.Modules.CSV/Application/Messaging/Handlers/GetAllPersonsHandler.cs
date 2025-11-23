using Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Commands;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Handlers
{
    internal class GetAllPersonsHandler : IRequestHandler<GetAllPersonsCommand, IReadOnlyCollection<Person>>
    {
        #region Constructors

        /// <summary>
        /// Returns a new instance of <see cref="CreateCharacterHandler"/>.
        /// </summary>
        /// <param name="repository">The corresponding repository</param>
        public GetAllPersonsHandler(IPersonRepository repository)
        {
            _repository = repository;
        }

        #endregion Constructors

        #region Fields

        private readonly IPersonRepository _repository;

        #endregion Fields

        #region Methods

        #region Public Methods

        /// <summary>
        /// Handles the creation of a new character based on the provided command.
        /// </summary>
        /// <remarks>This method creates a new character entity, persists it using the repository, and
        /// returns a data transfer object (DTO) representing the character.</remarks>
        /// <param name="request">The command containing the details of the character to be created, including name, race, and class.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a <see cref="CharacterDto"/> representing the created character.</returns>
        public async Task<IReadOnlyCollection<Person>> Handle(GetAllPersonsCommand request, CancellationToken cancellationToken)
        {
            var result = await _repository.GetAllAsync(cancellationToken);

            return result;
        }

        #endregion Public Methods

        #endregion Methods
    }
}
