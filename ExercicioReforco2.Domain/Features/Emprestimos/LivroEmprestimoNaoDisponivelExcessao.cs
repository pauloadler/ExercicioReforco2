using ExercicioReforco2.Domain.Exceptions;

namespace ExercicioReforco2.Domain.Features.Emprestimos
{
    public class LivroEmprestimoNaoDisponivelExcessao : BusinessException
    {
        public LivroEmprestimoNaoDisponivelExcessao() : base("Livro não está disponível!")
        {
        }
    }
}
