using ExercicioReforco2.Common.Tests.Base;
using ExercicioReforco2.Common.Tests.Features.Livros;
using ExercicioReforco2.Domain.Features.Livros;
using ExercicioReforco2.Infra.Data.Features.Livros;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco2.Infra.Data.Tests.Features.Livros
{
    [TestFixture]
    public class LivroRepositoryTests
    {
        LivroRepository _livroRepository;
        Livro _livroDefault;

        [SetUp]
        public void LivroRepositoryTestsTestSetUp()
        {
           BaseSqlTest.SeedDeleteDatabase();
           BaseSqlTest.SeedInsertDatabase();

            _livroRepository = new LivroRepository();
            _livroDefault = LivroObjectMother.Default;
        }

        [Test]
        public void Save_Deveria_Gravar_Uma_Nova_Livro()
        {
            //Action-Arrange
            Livro resultLivro = _livroRepository.Save(_livroDefault);

            //Assert
            Livro resultGet = _livroRepository.Get(resultLivro.Id);

            resultLivro.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultLivro.Id);
        }

        [Test]
        public void Update_Deveria_Alterar_Os_Dados_De_Livro()
        {
            //Arrange
            Livro livroResult = _livroRepository.Save(_livroDefault);
            livroResult.Volume = 18;

            //Action
            _livroRepository.Update(livroResult);

            //Assert
            Livro resultGet = _livroRepository.Get(livroResult.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(livroResult.Id);
            resultGet.Volume.Should().Be(18);
        }

        [Test]
        public void Get_Deveria_Retornar_Uma_Livro()
        {
            //Arrange
            Livro resultLivro = _livroRepository.Save(_livroDefault);

            //Action
            Livro resultGet = _livroRepository.Get(resultLivro.Id);

            //Assert
            resultLivro.Titulo.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultLivro);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_As_Livros()
        {
            //Arrange 
            Livro resultLivro = _livroRepository.Save(_livroDefault);

            //Action
            IList<Livro> resultGetAll = _livroRepository.GetAll();

            //Assert
            var ultimaLivro = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(2);
            ultimaLivro.Should().Equals(_livroDefault);
        }

        [Test]
        public void Delete_Deveria_Deletar_Uma_Livro()
        {
            //Arrange 
            Livro resultLivro = _livroRepository.Save(_livroDefault);

            //Action
            _livroRepository.Delete(resultLivro);

            //Assert
            Livro resultGet = _livroRepository.Get(resultLivro.Id);
            IList<Livro> resultGetAll = _livroRepository.GetAll();

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
