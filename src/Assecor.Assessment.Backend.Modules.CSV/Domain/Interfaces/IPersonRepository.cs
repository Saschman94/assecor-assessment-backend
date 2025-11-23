using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.Modules.CSV.Domain.Interfaces
{
    public interface IPersonRepository
    {
        #region Methods

        #region Public Methods

        Task<List<Person>> GetAllPersonsAsync(CancellationToken cancellationToken = default);

        Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<List<Person>> GetPersonsByColorAsync(int id, CancellationToken cancellationToken = default);

        #endregion Public Methods

        #endregion Methods
    }
}
