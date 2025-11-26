using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assecor.Assessment.Backend.Database.Models
{
    public class PeopleDbContext : DbContext
    {
        #region Constructors

        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {
        }

        #endregion Constructors

        #region Properties

        public DbSet<PersonEntity> Persons => Set<PersonEntity>();

        #endregion Properties

        #region Methods

        #region Protected Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PersonEntity>()
                .Property(p => p.Id)
                .ValueGeneratedNever();
        }

        #endregion Protected Methods

        #endregion Methods
    }
}
