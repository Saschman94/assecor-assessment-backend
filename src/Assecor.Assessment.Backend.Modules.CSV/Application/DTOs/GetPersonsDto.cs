using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.Modules.CSV.Application.DTOs
{
    public class GetPersonsDto
    {
        #region Properties

        public List<PersonDto> Persons { get; set; }

        #endregion Properties
    }
}
