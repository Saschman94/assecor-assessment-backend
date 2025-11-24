using Assecor.Assessment.Backend.Modules.CSV.Domain.Entities;
using Assecor.Assessment.Backend.Modules.CSV.Domain.Interfaces;
using Assecor.Assessment.Backend.Modules.CSV.Infrastructure.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Logging;
using System.Globalization;

namespace Assecor.Assessment.Backend.Modules.CSV.Infrastructure.CSV
{
    public class CsvPersonRepository : IPersonRepository
    {
        #region Constructors

        public CsvPersonRepository(CsvConfiguration csvConfiguration, string csvPath, ILogger<CsvPersonRepository> logger)
        {
            ArgumentNullException.ThrowIfNull(csvConfiguration);
            ArgumentNullException.ThrowIfNull(csvPath);
            ArgumentNullException.ThrowIfNull(logger);

            _csvConfiguration = csvConfiguration;
            _csvPath = csvPath;
            _logger = logger;
        }

        #endregion Constructors

        #region Fields

        private readonly CsvConfiguration _csvConfiguration;
        private readonly string _csvPath;
        private readonly ILogger<CsvPersonRepository> _logger;

        #endregion Fields

        #region Methods

        #region Private Static Methods

        private static (string zip, string city) ParseZipAndCity(string raw)
        {
            var parts = raw.Split(' ', 2, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length < 2)
                throw new FormatException($"Invalid zip/city format: '{raw}'");

            return (parts[0], parts[1]);
        }

        #endregion Private Static Methods

        #region Public Methods

        public Task<List<Person>> GetAllPersonsAsync(CancellationToken cancellationToken = default) => Task.FromResult(ReadAndParseCsv(cancellationToken));

        public Task<Person> GetPersonByIdAsync(int id, CancellationToken cancellationToken = default) => Task.FromResult(ReadAndParseCsv(cancellationToken).SingleOrDefault(p => p.Id == id) ?? throw new KeyNotFoundException($"Person with ID {id} not found."));

        public Task<List<Person>> GetPersonsByColorAsync(int id, CancellationToken cancellationToken = default)
        {
            var personsByColor = ReadAndParseCsv(cancellationToken).Where(p => (int)p.FavoriteColor == id) ?? throw new KeyNotFoundException($"No persons found with color ID {id}.");

            return Task.FromResult(personsByColor.ToList());
        }

        #endregion Public Methods

        #region Private Methods

        private List<Person> ReadAndParseCsv(CancellationToken cancellationToken)
        {
            var result = new List<Person>();

            using var reader = new StreamReader(_csvPath);
            using var csv = new CsvReader(reader, _csvConfiguration);

            csv.Context.RegisterClassMap<CsvPersonRowMap>();

            var id = 1;

            while (csv.Read())
            {
                cancellationToken.ThrowIfCancellationRequested();

                try
                {
                    var row = csv.GetRecord<CsvPersonRow>();

                    var (zip, city) = ParseZipAndCity(row.ZipAndCity);

                    var address = new Address(
                        new PostalCode(zip),
                        city
                    );

                    var color = Enum.IsDefined(typeof(Color), row.FavoriteColorCode)
                        ? (Color)row.FavoriteColorCode
                        : Color.Unknown;

                    var person = new Person(
                        id: id++,
                        name: row.FirstName.Trim(),
                        lastname: row.LastName.Trim(),
                        address: address,
                        favoriteColor: color
                    );

                    result.Add(person);
                }
                catch (Exception ex) when (
                    ex is CsvHelperException ||
                    ex is FormatException ||
                    ex is ArgumentException)
                {
                    var rowNumber = csv.Context.Parser.Row;
                    var record = csv.Context.Parser.Record;
                    var raw = record is null ? string.Empty : string.Join(" | ", record);

                    _logger.LogWarning(
                        ex,
                        "Error in CSV line {RowNumber}: '{Raw}'. Line will be ignored.",
                        rowNumber,
                        raw);
                }
            }

            return result;
        }

        #endregion Private Methods

        #endregion Methods
    }
}
