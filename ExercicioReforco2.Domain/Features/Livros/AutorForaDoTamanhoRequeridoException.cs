using ExercicioReforco2.Domain.Exceptions;

namespace ExercicioReforco2.Domain.Features.Livros
{
    public class AutorForaDoTamanhoRequeridoException : BusinessException
    {
        public AutorForaDoTamanhoRequeridoException() : base("Autor deve ter 4 caracteres!")
        {
        }
    }
}
