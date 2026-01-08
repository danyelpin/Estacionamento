namespace EstacionaBenner.Models;

public class TabelaPrecoResponseModel
{
    public int Id { get; set; }
    public DateTime InicioVigencia { get; set; }
    public DateTime FimVigencia { get; set; }
    public decimal ValorHoraInicial { get; set; }
    public decimal ValorHoraAdicional { get; set; }
    public bool Ativo { get; set; }
}