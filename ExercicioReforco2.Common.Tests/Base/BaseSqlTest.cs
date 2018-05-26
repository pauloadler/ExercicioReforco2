using ExercicioReforco2.Infra;

namespace ExercicioReforco2.Common.Tests.Base
{
    public static class BaseSqlTest
    {
        private const string RECREATE_LIVRO_TABLE = "DELETE FROM [dbo].[Livro]" +
                                                    "DBCC CHECKIDENT ('Livro', RESEED, 0)";

        private const string RECREATE_EMPRESTIMO_TABLE = "DELETE FROM [dbo].[Emprestimo]" +
                                                         "DBCC CHECKIDENT ('Emprestimo', RESEED, 0)";

        private const string INSERT = @"
                        DECLARE @livroId INT

                        INSERT INTO Livro(titulo, 
                                            tema, 
                                            autor, 
                                            volume, 
                                            data_publicacao, 
                                            disponibilidade)

                        VALUES('Titulo Teste', 'Tema Teste', 'Autor Teste', 2, GETDATE(), 1)

                        SET @livroId = @@IDENTITY

                        INSERT INTO Emprestimo(cliente, livro_id, data_devolucao)         
			            VALUES ('Cliente Teste', @livroId, GETDATE());";

        public static void SeedDeleteDatabase()
        {
            Db.Update(RECREATE_EMPRESTIMO_TABLE);
            Db.Update(RECREATE_LIVRO_TABLE);
        }

        public static void SeedInsertDatabase()
        {
            Db.Update(INSERT);
        }
    }
}
