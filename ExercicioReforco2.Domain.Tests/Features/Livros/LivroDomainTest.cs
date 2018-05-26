using ExercicioReforco2.Common.Tests.Features.Livros;
using ExercicioReforco2.Domain.Features.Livros;
using FluentAssertions;
using NUnit.Framework;
using System;

namespace ExercicioReforco2.Domain.Tests.Features.Livros
{
    [TestFixture]
    public class LivroDomainTest
    {
        Livro _livroDefault;

        [SetUp]
        public void LivroDomainTestSetUp()
        {
            _livroDefault = LivroObjectMother.Default;
        }

        [Test]
        public void Livro_nao_deve_possuir_titulo_com_menos_de_quatro_caracteres()
        {
            //Arrange
            Livro livro = LivroObjectMother.LivroTituloPequeno;

            //Action
            Action actionValidaTitulo = livro.ValidaTitulo;

            //Assert
            actionValidaTitulo.Should().Throw<TituloForaDoTamanhoRequeridoException>();
        }

        [Test]
        public void Livro_nao_deve_possuir_tema_com_menos_de_quatro_caracteres()
        {
            //Arrange
            Livro livro = LivroObjectMother.LivroTemaPequeno;

            //Action
            Action actionValidaTema = livro.ValidaTema;

            //Assert
            actionValidaTema.Should().Throw<TemaForaDoTamanhoRequeridoException>();
        }

        [Test]
        public void Livro_nao_deve_possuir_autor_com_menos_de_quatro_caracteres()
        {
            //Arrange
            Livro livro = LivroObjectMother.LivroAutorPequeno;

            //Action
            Action actionValidaAutor = livro.ValidaAutor;

            //Assert
            actionValidaAutor.Should().Throw<AutorForaDoTamanhoRequeridoException>();
        }

        [Test]
        public void Livro_nao_deve_possuir_volume_menor_que_zero()
        {
            //Arrange
            Livro livro = LivroObjectMother.LivroVolumeZero;

            //Action
            Action actionValidaVolume = livro.ValidaVolume;

            //Assert
            actionValidaVolume.Should().Throw<VolumeZeradoException>();
        }

        [Test]
        public void Livro_deve_possuir_todos_os_dados_quando_estiverem_corretors_e_validados()
        {
            //Action-Arrange
            Action actionValidaTitulo = _livroDefault.ValidaTitulo;
            Action actionValidaTema = _livroDefault.ValidaTema;
            Action actionValidaAutor = _livroDefault.ValidaAutor;
            Action actionValidaVolume = _livroDefault.ValidaVolume;

            //Assert
            actionValidaTitulo.Should().NotThrow<TituloForaDoTamanhoRequeridoException>();
            actionValidaTema.Should().NotThrow<TemaForaDoTamanhoRequeridoException>();
            actionValidaAutor.Should().NotThrow<AutorForaDoTamanhoRequeridoException>();
            actionValidaVolume.Should().NotThrow<VolumeZeradoException>();
        }
    }
}
