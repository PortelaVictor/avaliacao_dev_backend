namespace Vectra.Avaliacao.Backend.Application.DTOs
{
    public class ContaDto
    {
        public int Id { get; set; }
        public string Agencia { get; set; }
        public string Numero { get; set; }
        public string Cliente { get; set; }
        public double Saldo { get; set; }
    }
}