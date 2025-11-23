using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.Modules.CSV.Infrastructure.Models
{
    internal sealed class CsvPersonRowMap : ClassMap<CsvPersonRow>
    {
        #region Constructors

        public CsvPersonRowMap()
        {
            Map(m => m.LastName).Index(0);
            Map(m => m.FirstName).Index(1);
            Map(m => m.ZipAndCity).Index(2);
            Map(m => m.FavoriteColorCode).Index(3);
        }

        #endregion Constructors
    }
}
