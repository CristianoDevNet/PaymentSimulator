namespace simulator_back_end.Models
{
    public class SimCab
    {
        public int Id { get; set; }

        public int UsuarioId { get; set; }

        public string Titulo { get; set; }

        public decimal Juros { get; set; }

        public string Data { get; set; }

        public Usuario Usuario { get; set; }
    }
}