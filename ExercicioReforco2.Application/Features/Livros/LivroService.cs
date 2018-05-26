using System.Collections.Generic;
using ExercicioReforco2.Domain.Features.Livros;

namespace ExercicioReforco2.Application.Features.Livros
{
    public class LivroService : ILivroService
    {
        private ILivroRepository _livroRepository;

        public LivroService(ILivroRepository LivroRepository)
        {
            _livroRepository = LivroRepository;
        }

        public Livro Add(Livro livro)
        {
            return _livroRepository.Save(livro);
        }

        public void Update(Livro livro)
        {
            _livroRepository.Update(livro);
        }
        public Livro Get(long id)
        {
            return _livroRepository.Get(id);
        }

        public IList<Livro> GetAll()
        {
            return _livroRepository.GetAll();
        }

        public void Delete(Livro livro)
        {
            _livroRepository.Delete(livro);
        }
    }
}
