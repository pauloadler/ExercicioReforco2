using ExercicioReforco2.Domain.Features.Livros;
using System.Collections.Generic;

namespace ExercicioReforco2.Application.Features.Livros
{
    public interface ILivroService
    {
        Livro Add(Livro livro);

        void Update(Livro livro);

        Livro Get(long id);

        IList<Livro> GetAll();

        void Delete(Livro id);
    }
}
