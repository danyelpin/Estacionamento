using System.ComponentModel.DataAnnotations;

namespace EstacionaBenner.Models;

public class TabelaPrecoRequestModel
{
    [Required(ErrorMessage = "A data inicial é obrigatória")]
    public DateTime InicioVigencia { get; set; }

    [Required(ErrorMessage = "A data final é obrigatória")]
    public DateTime FimVigencia { get; set; }

    [Range(0.01, 1000, ErrorMessage = "O valor deve ser maior que zero")]
    public decimal ValorHoraInicial { get; set; }

    public decimal ValorHoraAdicional { get; set; }
}