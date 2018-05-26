using ExercicioReforco2.Domain.Exceptions;

namespace ExercicioReforco2.Domain.Features.Livros
{
    public class TituloForaDoTamanhoRequeridoException : BusinessException
    {
        public TituloForaDoTamanhoRequeridoException() : base("Titulo deve ter 4 caracteres!")
        {
        }
    }
}
