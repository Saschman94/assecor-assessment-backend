using Assecor.Assessment.Backend.Modules.SharedDomain.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.SharedDomain.Domain.Entities
{
    public class Person(int id, string name, string lastname, Address address, Color favoriteColor)
    {
        #region Properties

        public Address Address { get; } = address;

        public Color FavoriteColor { get; } = favoriteColor;

        public int Id { get; } = id;

        public string LastName { get; } = lastname;

        public string Name { get; } = name;

        #endregion Properties
    }
}
