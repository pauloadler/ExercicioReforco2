using ExercicioReforco2.Domain.Features.Emprestimos;
using System.Collections.Generic;

namespace ExercicioReforco2.Application.Features.Emprestimos
{
    public interface IEmprestimoService
    {
        Emprestimo Add(Emprestimo emprestimo);

        void Update(Emprestimo emprestimo);

        Emprestimo Get(long id);

        IList<Emprestimo> GetAll();

        void Delete(Emprestimo emprestimo);
    }
}
