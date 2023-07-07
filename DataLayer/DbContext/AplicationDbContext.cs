using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.DbContext
{
    public class AplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        #region constructor

        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options) { }

        #endregion

        #region dbsets
        public DbSet<Product> Products { get; set; }
        #endregion
    }
}