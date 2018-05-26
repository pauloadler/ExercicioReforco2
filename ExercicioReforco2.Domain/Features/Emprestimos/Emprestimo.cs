using ExercicioReforco2.Domain.Features.Livros;
using System;

namespace ExercicioReforco2.Domain.Features.Emprestimos
{
    public class Emprestimo
    {
        public long Id { get; set; }
        public string Cliente { get; set; }
        public Livro Livro { get; set; }
        public DateTime DataDevolucao { get; set; }
        public double MultaAtrasoDevolucao { get; set; }

        public void ValidaLivroDisponibilidade()
        {
            if (!Livro.Disponibilidade)
                throw new LivroEmprestimoNaoDisponivelExcessao();
        }

        public void ValidaNomeCliente()
        {
            if (string.IsNullOrEmpty(Cliente))
                throw new NomeClienteNuloExcessao();
        }

        public void CalculaMultaAtrasoDevolucao()
        {
            var diasAtraso = DateTime.Now.Day - DataDevolucao.Day;

            if (Id != 0)
            {
                if (diasAtraso != 0)
                    MultaAtrasoDevolucao = diasAtraso * 2.5;
            }
        }
    }
}
