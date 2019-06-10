namespace simulator_back_end.Models
{
    public class SimDet
    {
        public int Id { get; set; }

        public int SimCabId { get; set; }

        public int Parcela { get; set; }

        public decimal Valor { get; set; }

        public SimCab SimCab { get; set; }
    }
}