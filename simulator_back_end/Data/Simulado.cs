using System;

namespace simulator_back_end.Data
{
    public class Simulado
    {
        public decimal Valor { get; set; }

        public int QtdParcelas { get; set; }

        public decimal Juros { get; set; }

        public DateTime VencimentoDaPrimeiraParcela { get; set; }
    }
}