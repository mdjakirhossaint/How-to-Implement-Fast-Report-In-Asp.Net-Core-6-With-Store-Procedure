using FastReportIntegrateWithStoreProcedureInAspNetCore6.Entity;
using Microsoft.EntityFrameworkCore;

namespace FastReportIntegrateWithStoreProcedureInAspNetCore6.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>options):base(options)   
        {

        }
        public DbSet<TblCategory> Categories { get; set; }
        public DbSet<TblProduct> Products { get; set; }
    }
}
