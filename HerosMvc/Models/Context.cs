using Microsoft.EntityFrameworkCore;

namespace HerosMvc.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) 
        {
            

        }

        public DbSet<RoupasHeros> RoupasHeros { get; set; }

    }
}
