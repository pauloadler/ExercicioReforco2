using System;

namespace ExercicioReforco2.Domain.Features.Livros
{
    public class Livro
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Tema { get; set; }
        public string Autor { get; set; }
        public int Volume { get; set; }
        public DateTime DataPublicacao { get; set; }
        public bool Disponibilidade { get; set; }
       
        public void ValidaTitulo()
        {
            if (Titulo.Length < 4)
                throw new TituloForaDoTamanhoRequeridoException();
        }

        public void ValidaTema()
        {
            if (Tema.Length < 4)
                throw new TemaForaDoTamanhoRequeridoException();
        }

        public void ValidaAutor()
        {
            if (Autor.Length < 4)
                throw new AutorForaDoTamanhoRequeridoException();
        }

        public void ValidaVolume()
        {
            if (Volume == 0)
                throw new VolumeZeradoException();
        }
    }
}
