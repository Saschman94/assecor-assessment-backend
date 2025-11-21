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

        IReadOnlyCollection<Person> GetAll();

        #endregion Public Methods

        #endregion Methods
    }
}
