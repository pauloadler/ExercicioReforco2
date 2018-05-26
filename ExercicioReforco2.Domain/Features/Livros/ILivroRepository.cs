using System.Collections.Generic;

namespace ExercicioReforco2.Domain.Features.Livros
{
    public interface ILivroRepository
    {
        Livro Save(Livro livro);

        void Update(Livro livro);

        Livro Get(long id);

        IList<Livro> GetAll();

        void Delete(Livro livro);
    }
}
