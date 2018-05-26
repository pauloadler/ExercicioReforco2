using ExercicioReforco2.Domain.Exceptions;

namespace ExercicioReforco2.Domain.Features.Emprestimos
{
    public class NomeClienteNuloExcessao : BusinessException
    {
        public NomeClienteNuloExcessao() : base("Nome de cliente não pode ser nulo!")
        {
        }
    }
}
