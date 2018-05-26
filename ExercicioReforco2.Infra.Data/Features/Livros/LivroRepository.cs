using System;
using System.Collections.Generic;
using System.Data;
using ExercicioReforco2.Domain.Features.Livros;

namespace ExercicioReforco2.Infra.Data.Features.Livros
{

    public class LivroRepository : ILivroRepository
    {
        #region QUERIES

        private const string SqlInsereLivro =
            @"INSERT INTO Livro 
                (titulo, 
                 tema,
                 autor,
                 volume,
                 data_publicacao,
                 disponibilidade)
            VALUES
                (@titulo, 
                 @tema,
                 @autor,
                 @volume,
                 @data_publicacao,
                 @disponibilidade)";

        private const string SqlEditaLivro =
            @"UPDATE Livro
                SET
                     titulo = @titulo, 
                     tema = @tema,
                     autor = @autor,
                     volume = @volume,
                     data_publicacao = @data_publicacao,
                     disponibilidade = @disponibilidade
                WHERE id_livro = {0}id_livro";

        private const string SqlSelecionaTodosLivros =
           @"SELECT * FROM Livro";

        private const string SqlSelecionaLivroPorId =
           @"SELECT * FROM Livro WHERE id_livro = {0}id_livro";

        private const string SqlDeletaLivro =
           @"DELETE FROM Livro
                WHERE id_livro = {0}id_livro";


        #endregion QUERIES

        public Livro Save(Livro livro)
        {
            livro.Id = Db.Insert(SqlInsereLivro, GetParametros(livro));

            return livro;
        }

        public void Update(Livro livro)
        {
            Db.Update(SqlEditaLivro, GetParametros(livro));
        }

        public void Delete(Livro livro)
        {
            var parms = new Dictionary<string, object> { { "id_livro", livro.Id } };

            Db.Delete(SqlDeletaLivro, parms);
        }

        public Livro Get(long id)
        {
            var parms = new Dictionary<string, object> { { "id_livro", id } };

            return Db.Get(SqlSelecionaLivroPorId, Converter, parms);
        }

        public IList<Livro> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodosLivros, Converter);
        }

        private Dictionary<string, object> GetParametros(Livro livro)
        {
            return new Dictionary<string, object>
            {
                { "id_livro", livro.Id },
                { "titulo", livro.Titulo },
                { "tema", livro.Tema },
                { "autor", livro.Autor },
                { "volume", livro.Volume },
                { "data_publicacao", livro.DataPublicacao },
                { "disponibilidade", livro.Disponibilidade }
            };
        }

        private static Func<IDataReader, Livro> Converter = reader =>
         new Livro
         {
             Id = Convert.ToInt64(reader["id_livro"]),
             Titulo = reader["titulo"].ToString(),
             Tema = reader["tema"].ToString(),
             Autor = reader["autor"].ToString(),
             Volume = Convert.ToInt32(reader["volume"]),
             DataPublicacao = Convert.ToDateTime(reader["data_publicacao"]),
             Disponibilidade = Convert.ToBoolean(reader["disponibilidade"])
         };
    }
}

