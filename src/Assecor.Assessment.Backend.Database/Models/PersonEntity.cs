using System.ComponentModel.DataAnnotations.Schema;

namespace Assecor.Assessment.Backend.Database.Models
{
    public class PersonEntity
    {
        #region Properties

        public string City { get; set; } = default!;

        public int FavoriteColor { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string LastName { get; set; } = default!;

        public string Name { get; set; } = default!;

        public string PostalCode { get; set; } = default!;

        #endregion Properties
    }
}
