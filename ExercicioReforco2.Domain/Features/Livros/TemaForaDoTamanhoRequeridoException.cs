using ExercicioReforco2.Domain.Exceptions;

namespace ExercicioReforco2.Domain.Features.Livros
{
    public class TemaForaDoTamanhoRequeridoException : BusinessException
    {
        public TemaForaDoTamanhoRequeridoException() : base("Tema deve ter 4 caracteres!")
        {
        }
    }
}
