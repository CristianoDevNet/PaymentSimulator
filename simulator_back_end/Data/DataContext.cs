using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using simulator_back_end.Models;

namespace simulator_back_end.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Simulacao> Simulacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().HasData(
                new List<Usuario>() {
                    new Usuario{
                        Id = 1,
                        Email = "abc@abc.com",
                        Senha = "123"
                    }
                }
            );

            builder.Entity<Simulacao>().HasData(
                new List<Simulacao>() {
                    new Simulacao{
                        Id = 1,
                        UsuarioId = 1,
                        Titulo ="Fiat Uno Vivace",
                        Juros = 4.12m,
                        DataDaCompra = DateTime.Now
                    }
                }
            );
        }
    }
}