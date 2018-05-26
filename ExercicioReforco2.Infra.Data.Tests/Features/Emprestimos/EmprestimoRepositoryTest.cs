using ExercicioReforco2.Common.Tests.Base;
using ExercicioReforco2.Common.Tests.Features.Emprestimos;
using ExercicioReforco2.Domain.Features.Emprestimos;
using ExercicioReforco2.Infra.Data.Features.Emprestimos;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco2.Infra.Data.Tests.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoRepositoryTest
    {
        IEmprestimoRepository _emprestimoRepository;
        Emprestimo _emprestimoDefault;

        [SetUp]
        public void EmprestimoRepositoryTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _emprestimoRepository = new EmprestimoRepository();
            _emprestimoDefault = EmprestimoObjectMother.Default;
        }

        [Test]
        public void Save_Deveria_Gravar_Um_Novo_Emprestimo()
        {
            //Action-Arrange
            Emprestimo resultEmprestimo = _emprestimoRepository.Save(_emprestimoDefault);

            //Assert
            Emprestimo resultGet = _emprestimoRepository.Get(resultEmprestimo.Id);

            resultEmprestimo.Should().NotBeNull();
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultEmprestimo.Id);
        }

        [Test]
        public void Update_Deveria_Alterar_Os_Dados_De_Emprestimo()
        {
            //Arrange
            Emprestimo emprestimoResult = _emprestimoRepository.Save(_emprestimoDefault);
            emprestimoResult.Cliente = "Nome de Teste";

            //Action
            _emprestimoRepository.Update(emprestimoResult);

            //Assert
            Emprestimo resultGet = _emprestimoRepository.Get(emprestimoResult.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(emprestimoResult.Id);
            resultGet.Cliente.Should().Be("Nome de Teste");
        }

        [Test]
        public void Get_Deveria_Retornar_Um_Emprestimo()
        {
            //Arrange 
            Emprestimo resultEmprestimo = _emprestimoRepository.Save(_emprestimoDefault);

            //Action
            Emprestimo resultGet = _emprestimoRepository.Get(resultEmprestimo.Id);

            //Assert
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultEmprestimo.Id);
            resultGet.Should().Equals(resultEmprestimo);
        }

        [Test]
        public void GetAll_Deveria_Retornar_Todos_Os_Emprestimos()
        {
            //Arrange 
            Emprestimo resultEmprestimo = _emprestimoRepository.Save(_emprestimoDefault);

            //Action
            IList<Emprestimo> resultGetAll = _emprestimoRepository.GetAll();

            //Assert
            var ultimoEmprestimo = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(2);
            ultimoEmprestimo.Should().Equals(_emprestimoDefault);
        }

        [Test]
        public void Delete_Deveria_Deletar_Um_Emprestimo()
        {
            //Arrange 
            Emprestimo resultEmprestimo = _emprestimoRepository.Save(_emprestimoDefault);

            //Action
            _emprestimoRepository.Delete(resultEmprestimo);

            //Assert
            Emprestimo resultGet = _emprestimoRepository.Get(resultEmprestimo.Id);
            IList<Emprestimo> resultGetAll = _emprestimoRepository.GetAll();

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
