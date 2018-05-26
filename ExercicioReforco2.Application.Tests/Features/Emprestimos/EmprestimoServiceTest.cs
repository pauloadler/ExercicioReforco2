using ExercicioReforco2.Application.Features.Emprestimos;
using ExercicioReforco2.Common.Tests.Features.Emprestimos;
using ExercicioReforco2.Domain.Features.Emprestimos;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace ExercicioReforco2.Application.Tests.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoServiceTest
    {
        Mock<IEmprestimoRepository> _emprestimoRepositoryMockObject;
        EmprestimoService _emprestimoService;
        Emprestimo _emprestimoDefaultWithId;

        [SetUp]
        public void EmprestimoServiceTestSetUp()
        {
            _emprestimoRepositoryMockObject = new Mock<IEmprestimoRepository>();
            _emprestimoService = new EmprestimoService(_emprestimoRepositoryMockObject.Object);
            _emprestimoDefaultWithId = EmprestimoObjectMother.DefaultWithId;
        }

        [Test]
        public void Add_Deveria_incluir_Novo_Emprestimo()
        {
            //Arrange
            _emprestimoRepositoryMockObject.Setup(p => p.Save(It.IsAny<Emprestimo>())).Returns(_emprestimoDefaultWithId);

            //Action 
            Emprestimo retornoEmprestimo = _emprestimoService.Add(_emprestimoDefaultWithId);

            //Assert
            _emprestimoRepositoryMockObject.Verify(p => p.Save(It.IsAny<Emprestimo>()));
            _emprestimoRepositoryMockObject.Verify(p => p.Save(It.IsAny<Emprestimo>()), Times.Once());
            retornoEmprestimo.Id.Should().BeGreaterThan(0);
            retornoEmprestimo.Id.Should().Be(_emprestimoDefaultWithId.Id);
        }

        [Test]
        public void Update_Deveria_atualizar_Os_Dados_De_Emprestimo()
        {
            //Arrange
            _emprestimoRepositoryMockObject.Setup(p => p.Update(It.IsAny<Emprestimo>()));

            //Action
            Action actionEmprestimoUpdate = () => { _emprestimoService.Update(_emprestimoDefaultWithId); };

            //Assert
            actionEmprestimoUpdate.Should().NotThrow<Exception>();
            _emprestimoRepositoryMockObject.Verify(p => p.Update(It.IsAny<Emprestimo>()), Times.Once());
            _emprestimoRepositoryMockObject.Verify(p => p.Update(It.IsAny<Emprestimo>()));
        }

        [Test]
        public void Get_Deveria_Retornar_Um_Emprestimo()
        {
            //Arrange
            _emprestimoRepositoryMockObject.Setup(p => p.Get(It.IsAny<long>())).Returns(_emprestimoDefaultWithId);

            //Action 
            Emprestimo retornoEmprestimo = _emprestimoService.Get(_emprestimoDefaultWithId.Id);

            //Assert
            _emprestimoRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()));
            _emprestimoRepositoryMockObject.Verify(p => p.Get(It.IsAny<long>()), Times.Once());
            retornoEmprestimo.Id.Should().BeGreaterThan(0);
            retornoEmprestimo.Id.Should().Be(_emprestimoDefaultWithId.Id);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_Os_Emprestimos()
        {
            //Arrange
            IList<Emprestimo> _emprestimoDefaultList = EmprestimoObjectMother.DefaultListEmprestimos;

            _emprestimoRepositoryMockObject.Setup(p => p.GetAll()).Returns(_emprestimoDefaultList);

            //Action
            var resultEmprestimos = _emprestimoService.GetAll();

            //Assert
            _emprestimoRepositoryMockObject.Verify(x => x.GetAll());
            resultEmprestimos.Should().NotBeEmpty();
            resultEmprestimos.Should().HaveCount(3);
        }

        [Test]
        public void Delete_Deveria_Deletar_Um_Emprestimo()
        {
            //Arrange
            _emprestimoRepositoryMockObject.Setup(x => x.Delete(_emprestimoDefaultWithId));

            //Action
            Action emprestimoDeleteAction = () => _emprestimoService.Delete(_emprestimoDefaultWithId);
            
            //Assert
            emprestimoDeleteAction.Should().NotThrow<Exception>();
            _emprestimoRepositoryMockObject.Verify(x => x.Delete(_emprestimoDefaultWithId), Times.Once());
            _emprestimoRepositoryMockObject.Verify(x => x.Delete(_emprestimoDefaultWithId));
        }
    }
}
