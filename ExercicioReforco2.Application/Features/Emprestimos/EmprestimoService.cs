using System.Collections.Generic;
using ExercicioReforco2.Domain.Features.Emprestimos;

namespace ExercicioReforco2.Application.Features.Emprestimos
{
    public class EmprestimoService : IEmprestimoService
    {
        private IEmprestimoRepository _emprestimoRepository;

        public EmprestimoService(IEmprestimoRepository emprestimoRepository)
        {
            _emprestimoRepository = emprestimoRepository;
        }

        public Emprestimo Add(Emprestimo emprestimo)
        {
            return _emprestimoRepository.Save(emprestimo);
        }

        public void Delete(Emprestimo emprestimo)
        {
            _emprestimoRepository.Delete(emprestimo);
        }

        public Emprestimo Get(long id)
        {
            return _emprestimoRepository.Get(id);
        }

        public IList<Emprestimo> GetAll()
        {
            return _emprestimoRepository.GetAll();
        }

        public void Update(Emprestimo emprestimo)
        {
            _emprestimoRepository.Update(emprestimo);
        }
    }
}
