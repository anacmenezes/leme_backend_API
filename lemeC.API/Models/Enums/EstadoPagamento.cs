using System.ComponentModel;

namespace lemeC.API.Models.Enums
{
    public enum EstadoPagamento
    {
        [Description("Pendete")]
        Pendete = 1,
        [Description("Quitado")]
        Quitado = 2,
        [Description("Cancelado")]
        Cancelado = 3,
    }
}
