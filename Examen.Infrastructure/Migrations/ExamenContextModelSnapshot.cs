﻿// <auto-generated />
using System;
using Examen.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Examen.Infrastructure.Migrations
{
    [DbContext(typeof(ExamenContext))]
    partial class ExamenContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Commande", b =>
                {
                    b.Property<string>("NumCmd")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("DateCmd")
                        .HasColumnType("datetime2");

                    b.Property<bool>("livree")
                        .HasColumnType("bit");

                    b.Property<int>("livreurIdLivreur")
                        .HasColumnType("int");

                    b.HasKey("NumCmd");

                    b.HasIndex("livreurIdLivreur");

                    b.ToTable("commandes");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.LigneCommande", b =>
                {
                    b.Property<string>("CommandeFk")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("PlatFk")
                        .HasColumnType("int");

                    b.Property<int>("PlatIdPlat")
                        .HasColumnType("int");

                    b.Property<int>("Quantite")
                        .HasColumnType("int");

                    b.HasKey("CommandeFk", "PlatFk");

                    b.HasIndex("PlatIdPlat");

                    b.ToTable("ligneCommandes");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Livreur", b =>
                {
                    b.Property<int>("IdLivreur")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdLivreur"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("IdLivreur");

                    b.ToTable("livreurs");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Menu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateMenu")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("menus");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Plat", b =>
                {
                    b.Property<int>("IdPlat")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPlat"));

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.Property<string>("TypePlat")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdPlat");

                    b.ToTable("plats");
                });

            modelBuilder.Entity("MenuPlat", b =>
                {
                    b.Property<int>("PlatsIdPlat")
                        .HasColumnType("int");

                    b.Property<int>("menusId")
                        .HasColumnType("int");

                    b.HasKey("PlatsIdPlat", "menusId");

                    b.HasIndex("menusId");

                    b.ToTable("MenuPlat");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Commande", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Livreur", "livreur")
                        .WithMany("Commandes")
                        .HasForeignKey("livreurIdLivreur")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("livreur");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.LigneCommande", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Commande", "Commande")
                        .WithMany("LigneCommandes")
                        .HasForeignKey("CommandeFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Plat", "Plat")
                        .WithMany("LigneCommandes")
                        .HasForeignKey("PlatIdPlat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Commande");

                    b.Navigation("Plat");
                });

            modelBuilder.Entity("MenuPlat", b =>
                {
                    b.HasOne("Examen.ApplicationCore.Domain.Plat", null)
                        .WithMany()
                        .HasForeignKey("PlatsIdPlat")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Examen.ApplicationCore.Domain.Menu", null)
                        .WithMany()
                        .HasForeignKey("menusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Commande", b =>
                {
                    b.Navigation("LigneCommandes");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Livreur", b =>
                {
                    b.Navigation("Commandes");
                });

            modelBuilder.Entity("Examen.ApplicationCore.Domain.Plat", b =>
                {
                    b.Navigation("LigneCommandes");
                });
#pragma warning restore 612, 618
        }
    }
}
