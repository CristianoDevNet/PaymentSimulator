using System;

namespace simulator_back_end.Models
{
    public class Simulacao
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Titulo { get; set; }

        public decimal Juros { get; set; }

        public DateTime DataDaCompra { get; set; }

        public decimal ValorDaCompra { get; set; }

        public int QuantidadeDeParcelas { get; set; }

        public Usuario Usuario { get; set; }
    }
}