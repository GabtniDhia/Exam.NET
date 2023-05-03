
using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;

namespace Examen.Infrastructure
{
    public class ExamenContext: DbContext
    {
        public DbSet<Commande> commandes { get; set; }
        public DbSet<LigneCommande> ligneCommandes { get; set; }
        public DbSet<Livreur> livreurs { get; set; }
        public DbSet<Menu> menus { get; set; }
        public DbSet<Plat> plats { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;Initial Catalog=DhiaGabtni;Integrated Security=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commande>().HasKey(c => c.NumCmd);
            modelBuilder.Entity<LigneCommande>().HasKey(lc => new { lc.CommandeFk, lc.PlatFk });
            modelBuilder.Entity<Livreur>().HasKey(l => l.IdLivreur);
            modelBuilder.Entity<Menu>().HasKey(m => m.Id);
            modelBuilder.Entity<Plat>().HasKey(p => p.IdPlat);


        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
        }

    }
}