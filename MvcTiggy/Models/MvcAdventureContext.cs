using System;
using Microsoft.EntityFrameworkCore;

namespace MvcTiggy.Models
{
    public class MvcAdventureContext: DbContext
    {
        public MvcAdventureContext(DbContextOptions<MvcAdventureContext> options)
            : base(options)
        {
        }

        public DbSet<Adventure> Adventure { get; set; }
        public DbSet<Member> Members { get; set; }

    }
}
