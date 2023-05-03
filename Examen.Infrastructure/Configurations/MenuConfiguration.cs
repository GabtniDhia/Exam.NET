using Examen.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen.Infrastructure.Configurations
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            // Configurer la relation entre Menu et Plat afin qu’elle soit mappée vers une table nommée MyMenus

            builder.ToTable("MyMenus");
            builder.HasMany(m => m.Plats)
                .WithMany(p => p.menus);
        }
    }
}