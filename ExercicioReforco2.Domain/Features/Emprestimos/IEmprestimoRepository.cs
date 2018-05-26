using System.Collections.Generic;

namespace ExercicioReforco2.Domain.Features.Emprestimos
{
    public interface IEmprestimoRepository
    {
        Emprestimo Save(Emprestimo emprestimo);

        void Update(Emprestimo emprestimo);

        Emprestimo Get(long id);

        IList<Emprestimo> GetAll();

        void Delete(Emprestimo emprestimo);
    }
}
