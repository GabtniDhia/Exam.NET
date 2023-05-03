using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class LigneCommandesConfiguration : IEntityTypeConfiguration<LigneCommande>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<LigneCommande> builder)
        {

            builder.HasKey(x => new { x.CommandeFk, x.PlatFk });

            builder.HasOne(x => x.Commande)
                .WithMany(x => x.LigneCommandes)
                .HasForeignKey(x => x.CommandeFk);

            builder.HasOne(x => x.Plat)
                .WithMany(x => x.LigneCommandes)
                .HasForeignKey(x => x.PlatFk);
        }


    }
}
