using Banca.Conti.Repository.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banca.Conti.Repository
{
    public class ContiDbContext(DbContextOptions<ContiDbContext> options) : DbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Conto>(entity =>
            {
                // Definizione chiave primaria
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                // Configurazione IBAN (lunghezza standard massima 27 caratteri)
                entity.Property(e => e.Iban)
                      .IsRequired()
                      .HasMaxLength(27);

            });
        }
        public DbSet<Conto> Conti { get; set; }
    }
}
