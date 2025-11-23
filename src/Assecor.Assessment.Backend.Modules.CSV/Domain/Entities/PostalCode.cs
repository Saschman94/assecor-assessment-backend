using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.Modules.CSV.Domain.Entities
{
    public class PostalCode
    {
        #region Constructors

        public PostalCode(string value)
        {
            if (string.IsNullOrWhiteSpace(value)
                || value.Length != 5
                || !value.All(char.IsDigit))
            {
                throw new ArgumentException("Invalid postal code", nameof(value));
            }

            Value = value;
        }

        #endregion Constructors

        #region Properties

        public string Value { get; }

        #endregion Properties

        #region Methods

        #region Public Methods

        public override string ToString() => Value;

        #endregion Public Methods

        #endregion Methods
    }
}
