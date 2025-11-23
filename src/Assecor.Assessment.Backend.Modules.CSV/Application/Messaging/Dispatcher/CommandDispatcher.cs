using Assecor.Assessment.Backend.Modules.CSV.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.Modules.CSV.Application.Messaging.Dispatcher
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        #region Constructors

        public CommandDispatcher(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion Constructors

        #region Fields

        private readonly IMediator _mediator;

        #endregion Fields

        #region Methods

        #region Public Methods

        public Task<TResponse> Dispatch<TResponse>(IRequest<TResponse> command, CancellationToken ct = default)
            => _mediator.Send(command, ct);

        #endregion Public Methods

        #endregion Methods
    }
}
