using ExercicioReforco2.Common.Tests.Features.Livros;
using ExercicioReforco2.Domain.Features.Emprestimos;
using System;
using System.Collections.Generic;

namespace ExercicioReforco2.Common.Tests.Features.Emprestimos
{
    public class EmprestimoObjectMother
    {
        public static Emprestimo Default
        {
            get
            {
                return new Emprestimo()
                {
                    Cliente = "Teste",
                    DataDevolucao = DateTime.Now.AddDays(4),
                    Livro = LivroObjectMother.DefaultWithId
                };
            }
        }

        public static Emprestimo DefaultWithId
        {
            get
            {
                return new Emprestimo()
                {
                    Id = 1,
                    Cliente = "Teste",
                    DataDevolucao = DateTime.Now.AddDays(4),
                    Livro = LivroObjectMother.Default
                };
            }
        }

        public static Emprestimo NomeClienteVazio
        {
            get
            {
                return new Emprestimo()
                {
                    Cliente = "",
                    DataDevolucao = DateTime.Now.AddDays(4),
                    Livro = LivroObjectMother.Default
                };
            }
        }

        public static Emprestimo DevolucaoAtrasada
        {
            get
            {
                return new Emprestimo()
                {
                    Id = 1,
                    Cliente = "Teste",
                    DataDevolucao = DateTime.Now.AddDays(-4),
                    Livro = LivroObjectMother.Default
                };
            }
        }
        
        public static Emprestimo ComLivroSemDisponibilidade
        {
            get
            {
                return new Emprestimo()
                {
                    Cliente = "Teste",
                    DataDevolucao = DateTime.Now.AddDays(4),
                    Livro = LivroObjectMother.SemDisponibilidade
                };
            }
        }
        
        public static IList<Emprestimo> DefaultListEmprestimos
        {
            get
            {
                IList<Emprestimo> allEmprestimos = new List<Emprestimo>();

                allEmprestimos.Add(new Emprestimo()
                {
                    Cliente = "Teste1",
                    DataDevolucao = DateTime.Now.AddDays(4),
                    Livro = LivroObjectMother.Default
                });

                allEmprestimos.Add(new Emprestimo()
                {
                    Cliente = "Teste2",
                    DataDevolucao = DateTime.Now.AddDays(4),
                    Livro = LivroObjectMother.Default
                });

                allEmprestimos.Add(new Emprestimo()
                {
                    Cliente = "Teste3",
                    DataDevolucao = DateTime.Now.AddDays(4),
                    Livro = LivroObjectMother.Default
                });

                return allEmprestimos;
            }
        }
    }
}
