using Microsoft.EntityFrameworkCore;

namespace CP1Enterprise_EntityFramework_FIAP.Persistence
{
    public class OracleDbContext
    {
        public DbSet<Cartas> Cartas { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base (options) 
        {
        
        }
    }
}
