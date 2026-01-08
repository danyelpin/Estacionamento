namespace EstacionaBenner.Models;

public class RegistroEstacionamentoResponseModel
{
    public int Id { get; set; }
    public string Placa { get; set; }
    public DateTime HoraEntrada { get; set; }
    public DateTime? HoraSaida { get; set; }
    public decimal? ValorTotal { get; set; }
    
}