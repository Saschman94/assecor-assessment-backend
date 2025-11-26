using Assecor.Assessment.Backend.SharedDomain.Application.Interfaces;
using MediatR;

namespace Assecor.Assessment.Backend.SharedDomain.Application.Messaging.Dispatcher
{
    public class CommandDispatcher : ICommandDispatcher
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
