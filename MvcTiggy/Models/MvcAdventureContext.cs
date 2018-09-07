using System;
using Microsoft.EntityFrameworkCore;

namespace MvcTiggy.Models
{
    public class MvcAdventureContext : DbContext
    {
        public MvcAdventureContext(DbContextOptions<MvcAdventureContext> options)
            : base(options)
        {
        }

        public DbSet<Adventure> Adventure { get; set; }
        public DbSet<Member> Members { get; set; }

        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdventureMember>()
                        .HasKey(t => new { t.AdventureId, t.MemberId });
        }

        #endregion

    }
}
