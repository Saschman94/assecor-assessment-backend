using MediatR;

namespace Assecor.Assessment.Backend.SharedDomain.Application.Interfaces
{
    public interface ICommandDispatcher
    {
        #region Methods

        #region Public Methods

        /// <summary>
        /// Dispatches a command to the appropriate handler and returns the response.
        /// </summary>
        /// <remarks>This method is typically used to send a command to a handler that processes it and
        /// returns a result. Ensure that a suitable handler is registered for the command type.</remarks>
        /// <typeparam name="TResponse">The type of the response expected from the command.</typeparam>
        /// <param name="command">The command to be dispatched. Must implement <see cref="IRequest{TResponse}"/>.</param>
        /// <param name="ct">A cancellation token that can be used to cancel the operation. Defaults to <see
        /// cref="CancellationToken.None"/>.</param>
        /// <returns>A task representing the asynchronous operation, containing the response of type <typeparamref name="TResponse"/>.</returns>
        Task<TResponse> Dispatch<TResponse>(IRequest<TResponse> command, CancellationToken ct = default);

        #endregion Public Methods

        #endregion Methods
    }
}
