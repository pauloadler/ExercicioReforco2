GO
CREATE DATABASE ExercicioReforco2

USE [ExercicioReforco2]
GO
/****** Object:  Table [dbo].[Emprestimo]    Script Date: 23/05/2018 00:53:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Emprestimo](
	[id_emprestimo] [bigint] IDENTITY(1,1) NOT NULL,
	[cliente] [varchar](150) NOT NULL,
	[livro_id] [bigint] NOT NULL,
	[data_devolucao] [datetime] NOT NULL,
 CONSTRAINT [PK_Emprestimo] PRIMARY KEY CLUSTERED 
(
	[id_emprestimo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Livro]    Script Date: 23/05/2018 00:53:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Livro](
	[id_livro] [bigint] IDENTITY(1,1) NOT NULL,
	[titulo] [varchar](150) NOT NULL,
	[tema] [varchar](150) NOT NULL,
	[autor] [varchar](150) NOT NULL,
	[volume] [int] NOT NULL,
	[data_publicacao] [datetime] NOT NULL,
	[disponibilidade] [bit] NOT NULL,
 CONSTRAINT [PK_Livro] PRIMARY KEY CLUSTERED 
(
	[id_livro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Emprestimo]  WITH CHECK ADD  CONSTRAINT [fk_livro] FOREIGN KEY([livro_id])
REFERENCES [dbo].[Livro] ([id_livro])
GO
ALTER TABLE [dbo].[Emprestimo] CHECK CONSTRAINT [fk_livro]
GO

