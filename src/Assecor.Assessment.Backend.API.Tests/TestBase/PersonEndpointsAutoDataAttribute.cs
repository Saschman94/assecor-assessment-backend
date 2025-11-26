using Assecor.Assessment.Backend.Modules.SharedDomain.Domain.Entities;
using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoFixture.Xunit2;

namespace Assecor.Assessment.Backend.API.Tests.TestBase
{
    public class PersonEndpointsAutoDataAttribute : AutoDataAttribute
    {
        #region Constructors

        public PersonEndpointsAutoDataAttribute() : base(() =>
        {
            var fixture = new Fixture().Customize(new AutoNSubstituteCustomization
            {
                ConfigureMembers = true
            });

            fixture.Register(() =>
            {
                var rnd = Random.Shared.Next(0, 100000);
                var zip = rnd.ToString("00000");
                return new PostalCode(zip);
            });

            return fixture;
        })
        {
        }

        #endregion Constructors
    }
}
