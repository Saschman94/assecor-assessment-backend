using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.Modules.CSV.Domain.Entities
{
    public record Person
    {
        #region Properties

        public string City { get; set; }

        public Color ColorCode  { get; set; }

        public int Id { get; set; }

        public string LastName  { get; set; }

        public string Name { get; set; }

        #endregion Properties
    }
}
