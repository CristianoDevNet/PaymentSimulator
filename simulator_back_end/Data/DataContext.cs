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

        public DbSet<SimCab> SimCabs { get; set; }

        public DbSet<SimDet> SimDets { get; set; }

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

            builder.Entity<SimCab>().HasData(
                new List<SimCab>() {
                    new SimCab{
                        Id = 1,
                        UsuarioId = 1,
                        Titulo ="Fiat Uno Vivace",
                        Juros = 4.12m,
                        Data = DateTime.Now.ToShortDateString()
                    }
                }
            );

            builder.Entity<SimDet>().HasData(
                new List<SimDet>() {
                    new SimDet{Id = 1, SimCabId = 1,   Parcela = 1,  Valor = 8234.12m, Vencimento = DateTime.Now.AddMonths(1) },
                    new SimDet{Id = 2, SimCabId = 1,   Parcela = 2,  Valor = 8234.12m, Vencimento = DateTime.Now.AddMonths(2) },
                    new SimDet{Id = 3, SimCabId = 1,   Parcela = 3,  Valor = 8234.12m, Vencimento = DateTime.Now.AddMonths(3) }
                }
            );
        }
    }
}