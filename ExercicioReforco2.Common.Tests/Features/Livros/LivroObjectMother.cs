
using ExercicioReforco2.Domain.Features.Livros;
using System;
using System.Collections.Generic;

namespace ExercicioReforco2.Common.Tests.Features.Livros
{
    public class LivroObjectMother
    {
        public static Livro Default
        {
            get
            {
                return new Livro()
                {
                    Titulo = "Teste",
                    Tema = "Tema Teste",
                    Autor = "Autor Teste",
                    Volume = 23,
                    DataPublicacao = DateTime.Now,
                    Disponibilidade = true
                };
            }
        }

        public static Livro DefaultWithId
        {
            get
            {
                return new Livro()
                {
                    Id = 1,
                    Titulo = "Teste",
                    Tema = "Tema Teste",
                    Autor = "Autor Teste",
                    Volume = 23,
                    DataPublicacao = DateTime.Now,
                    Disponibilidade = true
                };
            }
        }

        public static Livro SemDisponibilidade
        {
            get
            {
                return new Livro()
                {
                    Titulo = "Teste",
                    Tema = "Tema Teste",
                    Autor = "Autor Teste",
                    Volume = 23,
                    DataPublicacao = DateTime.Now,
                    Disponibilidade = false
                };
            }
        }

        public static Livro LivroTituloPequeno
        {
            get
            {
                return new Livro()
                {
                    Titulo = "Tes",
                    Tema = "Tema Teste",
                    Autor = "Autor Teste",
                    Volume = 23,
                    DataPublicacao = DateTime.Now,
                    Disponibilidade = true
                };
            }
        }

        public static Livro LivroTemaPequeno
        {
            get
            {
                return new Livro()
                {
                    Titulo = "Teste",
                    Tema = "Tem",
                    Autor = "Autor Teste",
                    Volume = 23,
                    DataPublicacao = DateTime.Now,
                    Disponibilidade = true
                };
            }
        }

        public static Livro LivroAutorPequeno
        {
            get
            {
                return new Livro()
                {
                    Titulo = "Teste",
                    Tema = "Tema Teste",
                    Autor = "Au",
                    Volume = 23,
                    DataPublicacao = DateTime.Now,
                    Disponibilidade = true
                };
            }
        }

        public static Livro LivroVolumeZero
        {
            get
            {
                return new Livro()
                {
                    Titulo = "Teste",
                    Tema = "Tema Teste",
                    Autor = "Au",
                    Volume = 0,
                    DataPublicacao = DateTime.Now,
                    Disponibilidade = true
                };
            }
        }

        public static IList<Livro> DefaultListLivros
        {
            get
            {
                IList<Livro> allLivros = new List<Livro>();

                allLivros.Add(new Livro()
                {
                    Titulo = "Teste",
                    Tema = "Tema Teste",
                    Autor = "Autor",
                    Volume = 23,
                    DataPublicacao = DateTime.Now,
                    Disponibilidade = true
                });

                allLivros.Add(new Livro()
                {
                    Titulo = "Teste",
                    Tema = "Tema Teste",
                    Autor = "Autor",
                    Volume = 23,
                    DataPublicacao = DateTime.Now,
                    Disponibilidade = true
                });

                allLivros.Add(new Livro()
                {
                    Titulo = "Teste",
                    Tema = "Tema Teste",
                    Autor = "Autor",
                    Volume = 23,
                    DataPublicacao = DateTime.Now,
                    Disponibilidade = true
                });

                return allLivros;
            }
        }
    }
}
