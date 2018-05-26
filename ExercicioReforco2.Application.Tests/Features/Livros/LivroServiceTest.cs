using ExercicioReforco2.Application.Features.Livros;
using ExercicioReforco2.Common.Tests.Features.Livros;
using ExercicioReforco2.Domain.Features.Livros;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExercicioReforco2.Application.Tests.Features.Livros
{
    [TestFixture]
    public class LivroServiceTest
    {
        Mock<ILivroRepository> _livroRepositoryMockObject;
        LivroService _livroService;
        Livro _livroefaultWithId;

        [SetUp]
        public void LivroServiceTestSetUp()
        {
            _livroRepositoryMockObject = new Mock<ILivroRepository>();
            _livroService = new LivroService(_livroRepositoryMockObject.Object);
            _livroefaultWithId = LivroObjectMother.DefaultWithId;
        }

        [Test]
        public void Add_Deveria_incluir_Novo_Livro()
        {
            //Arrange
            _livroRepositoryMockObject.Setup(p => p.Save(It.IsAny<Livro>())).Returns(_livroefaultWithId);

            //Action 
            Livro retornoLivro = _livroService.Add(_livroefaultWithId);

            //Assert
            _livroRepositoryMockObject.Verify(p => p.Save(It.IsAny<Livro>()));
            _livroRepositoryMockObject.Verify(p => p.Save(It.IsAny<Livro>()), Times.Once());
            retornoLivro.Id.Should().BeGreaterThan(0);
            retornoLivro.Id.Should().Be(_livroefaultWithId.Id);
        }

        [Test]
        public void Update_Deveria_atualizar_Os_Dados_Do_Livro()
        {
            //Arrange
            _livroRepositoryMockObject.Setup(p => p.Update(It.IsAny<Livro>()));

            //Action
            Action actionLivroUpdate = () => { _livroService.Update(_livroefaultWithId); };

            //Assert
            actionLivroUpdate.Should().NotThrow<Exception>();
            _livroRepositoryMockObject.Verify(p => p.Update(It.IsAny<Livro>()), Times.Once());
            _livroRepositoryMockObject.Verify(p => p.Update(It.IsAny<Livro>()));
        }

        [Test]
        public void Get_Deveria_Retornar_Um_Livro()
        {
            //Arrange
            _livroRepositoryMockObject.Setup(p => p.Get(It.IsAny<long>())).Returns(_livroefaultWithId);

            //Action 
            Livro retornoLivro = _livroService.Get(_livroefaultWithId.Id);

            //Assert
            _livroRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()));
            _livroRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()), Times.Once());
            retornoLivro.Id.Should().BeGreaterThan(0);
            retornoLivro.Id.Should().Be(_livroefaultWithId.Id);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_Os_Livros()
        {
            //Arrange
            IList<Livro> _livroDefaultList = LivroObjectMother.DefaultListLivros;

            _livroRepositoryMockObject.Setup(p => p.GetAll()).Returns(_livroDefaultList);

            //Action
            var resultLivros = _livroService.GetAll();

            //Assert
            _livroRepositoryMockObject.Verify(x => x.GetAll());
            resultLivros.Should().NotBeEmpty();
            resultLivros.Should().HaveCount(3);
        }

        [Test]
        public void Delete_Deveria_Deletar_Um_Livro()
        {
            //Arrange
            _livroRepositoryMockObject.Setup(x => x.Delete(_livroefaultWithId));

            //Action
            Action livroDeleteAction = () => _livroService.Delete(_livroefaultWithId);

            //Assert
            livroDeleteAction.Should().NotThrow<Exception>();
            _livroRepositoryMockObject.Verify(x => x.Delete(_livroefaultWithId), Times.Once());
            _livroRepositoryMockObject.Verify(x => x.Delete(_livroefaultWithId));
        }
    }
}

