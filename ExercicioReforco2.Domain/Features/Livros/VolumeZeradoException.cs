using ExercicioReforco2.Domain.Exceptions;

namespace ExercicioReforco2.Domain.Features.Livros
{
    public class VolumeZeradoException : BusinessException
    {
        public VolumeZeradoException() : base("Volume não deve ser zerado!")
        {
        }
    }
}
