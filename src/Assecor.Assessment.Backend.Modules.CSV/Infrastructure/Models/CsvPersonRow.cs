namespace Assecor.Assessment.Backend.Modules.CSV.Infrastructure.Models
{
    internal record CsvPersonRow
    {
        #region Properties

        public int FavoriteColorCode { get; set; } = 0;

        public string FirstName { get; set; } = string.Empty;

        public int Id { get; set; } = 0;

        public string LastName { get; set; } = string.Empty;

        public string ZipAndCity { get; set; } = string.Empty;

        #endregion Properties
    }
}
