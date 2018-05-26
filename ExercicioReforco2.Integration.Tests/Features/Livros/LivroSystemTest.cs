using ExercicioReforco2.Application.Features.Livros;
using ExercicioReforco2.Common.Tests.Base;
using ExercicioReforco2.Common.Tests.Features.Livros;
using ExercicioReforco2.Domain.Features.Livros;
using ExercicioReforco2.Infra.Data.Features.Livros;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco2.Integration.Tests.Features.Livros
{
    [TestFixture]
    public class LivroSystemTest
    {
        ILivroRepository _livroRepository;
        LivroService _livroService;
        Livro _livroDefault;

        [SetUp]
        public void LivroSystemTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _livroRepository = new LivroRepository();
            _livroService = new LivroService(_livroRepository);
            _livroDefault = LivroObjectMother.Default;
        }

        [Test]
        public void Sistema_Deveria_Salvar_Um_Novo_Livro_E_Retornar_Do_Banco()
        {
            //Action-Arrange
            Livro resultLivro = _livroService.Add(_livroDefault);

            //Assert
            resultLivro.Should().NotBeNull();
            resultLivro.Id.Should().NotBe(0);

            Livro resultGet = _livroService.Get(resultLivro.Id);
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultLivro);
        }

        [Test]
        public void Sistema_Deveria_Alterar_Um_Livro_Pelo_Id()
        {
            //Arrange
            Livro resultLivro = _livroService.Add(_livroDefault);
            resultLivro.Tema = "Tema Atualizado";

            //Action 
            _livroService.Update(resultLivro);

            //Assert
            Livro resultGet = _livroService.Get(resultLivro.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultLivro.Id);
            resultGet.Tema.Should().Be("Tema Atualizado");
        }

        [Test]
        public void Sistema_Deveria_Buscar_Um_Livro_Pelo_Id()
        {
            //Arrange 
            Livro resultLivro = _livroService.Add(_livroDefault);

            //Action
            Livro resultGet = _livroService.Get(resultLivro.Id);

            //Assert
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultLivro.Id);
            resultGet.Should().Equals(resultLivro);
        }

        [Test]
        public void Sistema_Deveria_Buscar_Todos_Os_Livro()
        {
            //Arrange 
            Livro resultLivro = _livroService.Add(_livroDefault);

            //Action
            IList<Livro> resultGetAll = _livroService.GetAll();

            //Assert
            var ultimaLivro = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(2);
            ultimaLivro.Should().Equals(_livroDefault);
        }

        [Test]
        public void Sistema_Deveria_Deletar_Um_Livro_Pelo_Id()
        {
            Livro resultLivro = _livroService.Add(_livroDefault);

            //Action
            _livroService.Delete(resultLivro);

            //Assert
            Livro resultGet = _livroService.Get(resultLivro.Id);
            IList<Livro> resultGetAll = _livroService.GetAll();

            resultGet.Should().BeNull();
            resultGetAll.Should().HaveCount(1);
        }

        [TearDown]
        public void LimparDataBase()
        {
            BaseSqlTest.SeedDeleteDatabase();
        }
    }
}
