
using iService.Data.Mappings;
using iService.Models;
using Microsoft.EntityFrameworkCore;

namespace iService.Data
{
    public class iServiceDataContext : DbContext
    {
        public DbSet<Collaborator> Collaborators { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<Sector> Sectors { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer("Server=localhost,1433;Database=iService;User ID=sa;Password=1q2w3e4r@#$;Encrypt=false");
        protected override void OnModelCreating(ModelBuilder model)
        {
            model.ApplyConfiguration(new CollaboratorMap());
            model.ApplyConfiguration(new FunctionMap());
            model.ApplyConfiguration(new SectorMap());
        }
    }
}