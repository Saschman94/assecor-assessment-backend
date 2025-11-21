using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Interfaces;

namespace Assecor.Assessment.Backend.Modules.CSV.Infrastructure.CSV
{
    public class CsvPersonRepository : IPersonRepository
    {
        #region Constructors

        public CsvPersonRepository(string csvPath)
        {
            ArgumentNullException.ThrowIfNull(csvPath);

            _csvPath = csvPath;
        }

        #endregion Constructors

        #region Fields

        private readonly string _csvPath;

        #endregion Fields

        #region Methods

        #region Private Static Methods

        private static Color MapColor(int colorCode) => Enum.IsDefined(typeof(Color), colorCode) ? (Color)colorCode : Color.Unknown;

        #endregion Private Static Methods

        #region Public Methods

        public IReadOnlyCollection<Person> GetAll()
        {
            var lines = File.ReadAllLines(_csvPath);
            var result = new List<Person>();

            foreach (var line in lines)
            {
                int lineCounter = 0;
                var parts = line.Split(';');
                var colorCode = int.Parse(parts[3]);

                result.Add(new Person()
                {
                    Id = lineCounter++,
                    Name = parts[0],
                    LastName = parts[1],
                    City = parts[2],
                    ColorCode = MapColor(colorCode)
                });
            }
            return result;
        }

        #endregion Public Methods

        #endregion Methods
    }
}
