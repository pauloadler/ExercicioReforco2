using System;
using System.Collections.Generic;
using System.Data;
using ExercicioReforco2.Domain.Features.Emprestimos;
using ExercicioReforco2.Domain.Features.Livros;

namespace ExercicioReforco2.Infra.Data.Features.Emprestimos
{
    public class EmprestimoRepository : IEmprestimoRepository
    {
        #region QUERIES

        private const string SqlInsereEmprestimo =
            @"INSERT INTO Emprestimo
                (cliente,
                 livro_id,
                 data_devolucao)
            VALUES
                (@cliente, 
                 @livro_id, 
                 @data_devolucao)";

        private const string SqlEditaEmprestimo =
            @"UPDATE Emprestimo
                SET
                    cliente = @cliente, 
                    livro_id = @livro_id,
                    data_devolucao = @data_devolucao
                WHERE id_emprestimo = {0}id_emprestimo";

        private const string SqlSelecionaTodosEmprestimos =
           @"SELECT 
               *
            FROM
                Emprestimo
            INNER JOIN Livro on Livro.id_livro = Emprestimo.livro_id";

        private const string SqlSelecionaEmprestimoPorId =
           @"SELECT
                 *
            FROM
                Emprestimo
            INNER JOIN Livro on Livro.id_livro = Emprestimo.livro_id
            WHERE id_emprestimo = {0}id_emprestimo";

        private const string SqlDeletaEmprestimo =
           @"DELETE FROM Emprestimo
                WHERE id_emprestimo = {0}id_emprestimo";


        #endregion QUERIES

        public Emprestimo Save(Emprestimo Emprestimo)
        {
            Emprestimo.Id = Db.Insert(SqlInsereEmprestimo, GetParametros(Emprestimo));

            return Emprestimo;
        }

        public void Update(Emprestimo Emprestimo)
        {
            Db.Update(SqlEditaEmprestimo, GetParametros(Emprestimo));
        }

        public void Delete(Emprestimo Emprestimo)
        {
            var parms = new Dictionary<string, object> { { "id_emprestimo", Emprestimo.Id } };

            Db.Delete(SqlDeletaEmprestimo, parms);
        }

        public Emprestimo Get(long id)
        {
            var parms = new Dictionary<string, object> { { "id_emprestimo", id } };

            return Db.Get(SqlSelecionaEmprestimoPorId, Converter, parms);
        }

        public IList<Emprestimo> GetAll()
        {
            return Db.GetAll(SqlSelecionaTodosEmprestimos, Converter);
        }

        private Dictionary<string, object> GetParametros(Emprestimo emprestimo)
        {
            return new Dictionary<string, object>
            {
                { "id_emprestimo", emprestimo.Id },
                { "cliente", emprestimo.Cliente },
                { "livro_id", emprestimo.Livro.Id },
                { "data_devolucao", emprestimo.DataDevolucao }
            };
        }

        private static Func<IDataReader, Emprestimo> Converter = reader =>
         new Emprestimo
         {
             Id = Convert.ToInt64(reader["id_emprestimo"]),
             Cliente = Convert.ToString(reader["cliente"]),
             Livro = new Livro()
             {
                 Id = Convert.ToInt64(reader["id_livro"]),
                 Titulo = reader["titulo"].ToString(),
                 Tema = reader["tema"].ToString(),
                 Autor = reader["autor"].ToString(),
                 Volume = Convert.ToInt32(reader["volume"]),
                 DataPublicacao = Convert.ToDateTime(reader["data_publicacao"]),
                 Disponibilidade = Convert.ToBoolean(reader["disponibilidade"])
             },
             DataDevolucao = Convert.ToDateTime(reader["data_devolucao"])
         };
    }
}
