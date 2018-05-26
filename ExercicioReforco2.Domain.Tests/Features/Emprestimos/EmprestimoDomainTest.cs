using ExercicioReforco2.Common.Tests.Features.Emprestimos;
using ExercicioReforco2.Domain.Features.Emprestimos;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace ExercicioReforco2.Domain.Tests.Features.Emprestimos
{
    [TestFixture]
    public class EmprestimoDomainTest
    {
        Emprestimo _emprestimoDefault;

        [SetUp]
        public void EmprestimoDomainTestSetUp()
        {
            _emprestimoDefault = EmprestimoObjectMother.Default;
        }

        [Test]
        public void Emprestimo_nao_deve_possuir_livro_sem_disponibilidade()
        {
            //Arrange
            Emprestimo emprestimo = EmprestimoObjectMother.ComLivroSemDisponibilidade;

            //Action
            Action actionValidaLivroDisponibilidade = emprestimo.ValidaLivroDisponibilidade;

            //Assert
            actionValidaLivroDisponibilidade.Should().Throw<LivroEmprestimoNaoDisponivelExcessao>();
        }

        [Test]
        public void Emprestimo_deve_calcular_a_multa_de_atraso_quando_emprestimo_ja_tiver_sido_cadastrado()
        {
            //Arrange
            Emprestimo emprestimo = EmprestimoObjectMother.DevolucaoAtrasada;

            //Action
            emprestimo.CalculaMultaAtrasoDevolucao();

            //Assert
            emprestimo.MultaAtrasoDevolucao.Should().NotBe(0);
            emprestimo.MultaAtrasoDevolucao.Should().Be(10);
        }
        
        [Test]
        public void Emprestimo_nao_deve_calcular_a_multa_de_atraso_quando_emprestimo_nao_tiver_sido_cadastrado()
        {
            //Arrange
            Emprestimo emprestimo = EmprestimoObjectMother.Default;

            //Action
            emprestimo.CalculaMultaAtrasoDevolucao();

            //Assert
            emprestimo.MultaAtrasoDevolucao.Should().Be(0);
        }

        [Test]
        public void Emprestimo_nao_deve_ter_cliente_vazio()
        {
            //Arrange
            Emprestimo emprestimo = EmprestimoObjectMother.NomeClienteVazio;

            //Action
            Action actionValidaCliente = emprestimo.ValidaNomeCliente;

            //Assert
            actionValidaCliente.Should().Throw<NomeClienteNuloExcessao>();
        }

        [Test]
        public void Emprestimo_deve_possuir_todos_os_dados_quando_estiverem_corretors_e_validados()
        {
            //Action-Arrange
            Action actionValidaTitulo = _emprestimoDefault.ValidaLivroDisponibilidade;
            Action actionValidaLivroDisponibilidade = _emprestimoDefault.ValidaNomeCliente;
            
            //Assert
            actionValidaTitulo.Should().NotThrow<Exception>();
            actionValidaLivroDisponibilidade.Should().NotThrow<Exception>();
        }
    }
}
