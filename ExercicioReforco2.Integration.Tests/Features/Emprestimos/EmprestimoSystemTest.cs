using ExercicioReforco2.Application.Features.Emprestimos;
using ExercicioReforco2.Common.Tests.Base;
using ExercicioReforco2.Common.Tests.Features.Emprestimos;
using ExercicioReforco2.Domain.Features.Emprestimos;
using ExercicioReforco2.Infra.Data.Features.Emprestimos;
using FluentAssertions;
using NUnit.Framework;
using System.Collections.Generic;

namespace ExercicioReforco2.System.Tests.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoSystemTest
    {
        IEmprestimoRepository _emprestimoRepository;
        EmprestimoService _emprestimoService;
        Emprestimo _emprestimoDefault;

        [SetUp]
        public void EmprestimoSystemTestSetUp()
        {
            BaseSqlTest.SeedDeleteDatabase();
            BaseSqlTest.SeedInsertDatabase();

            _emprestimoRepository = new EmprestimoRepository();
            _emprestimoService = new EmprestimoService(_emprestimoRepository);
            _emprestimoDefault = EmprestimoObjectMother.Default;
        }

        [Test]
        public void Sistema_Deveria_Salvar_Um_Novo_Emprestimo_E_Retornar_Do_Banco()
        {
            //Action-Arrange
            Emprestimo resultEmprestimo = _emprestimoService.Add(_emprestimoDefault);

            //Assert
            resultEmprestimo.Should().NotBeNull();
            resultEmprestimo.Id.Should().NotBe(0);

            Emprestimo resultGet = _emprestimoService.Get(resultEmprestimo.Id);
            resultGet.Should().NotBeNull();
            resultGet.Should().Equals(resultEmprestimo);
        }

        [Test]
        public void Sistema_Deveria_Alterar_Um_Emprestimo_Pelo_Id()
        {
            //Arrange
            Emprestimo resultEmprestimo = _emprestimoService.Add(_emprestimoDefault);
            resultEmprestimo.Cliente = "Cliente Atualizado";

            //Action 
            _emprestimoService.Update(resultEmprestimo);

            //Assert
            Emprestimo resultGet = _emprestimoService.Get(resultEmprestimo.Id);

            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultEmprestimo.Id);
            resultGet.Cliente.Should().Be("Cliente Atualizado");
        }

        [Test]
        public void Sistema_Deveria_Buscar_Um_Emprestimo_Pelo_Id()
        {
            //Arrange 
            Emprestimo resultEmprestimo = _emprestimoService.Add(_emprestimoDefault);

            //Action
            Emprestimo resultGet = _emprestimoService.Get(resultEmprestimo.Id);

            //Assert
            resultGet.Should().NotBeNull();
            resultGet.Id.Should().Be(resultEmprestimo.Id);
            resultGet.Should().Equals(resultEmprestimo);
        }

        [Test]
        public void Sistema_Deveria_Buscar_Todos_Os_Emprestimo()
        {
            //Arrange 
            Emprestimo resultEmprestimo = _emprestimoService.Add(_emprestimoDefault);

            //Action
            IList<Emprestimo> resultGetAll = _emprestimoService.GetAll();

            //Assert
            var ultimoEmprestimo = resultGetAll[resultGetAll.Count - 1];

            resultGetAll.Should().NotHaveCount(0);
            resultGetAll.Should().HaveCount(2);
            ultimoEmprestimo.Should().Equals(_emprestimoDefault);
        }

        [Test]
        public void Sistema_Deveria_Deletar_Um_Emprestimo_Pelo_Id()
        {
            Emprestimo resultEmprestimo = _emprestimoService.Add(_emprestimoDefault);

            //Action
            _emprestimoService.Delete(resultEmprestimo);

            //Assert
            Emprestimo resultGet = _emprestimoService.Get(resultEmprestimo.Id);
            IList<Emprestimo> resultGetAll = _emprestimoService.GetAll();

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
