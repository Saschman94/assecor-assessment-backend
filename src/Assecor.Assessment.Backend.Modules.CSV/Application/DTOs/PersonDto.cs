using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.Modules.CSV.Application.DTOs
{
    public class PersonDto
    {
        #region Properties

        public string City { get; set; }

        public int ColorCode  { get; set; }

        public int Id { get; set; }

        public string LastName  { get; set; }

        public string Name { get; set; }

        public string ZipCode { get; set; }

        #endregion Properties
    }
}
