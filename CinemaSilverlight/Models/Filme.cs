using System;
using System.Collections.Generic;

namespace CinemaSL.Models
{
    public class Filme
    {
        public Filme() { }

        public Filme(string nome, int duracao)
        {
            this.Nome = nome;
            this.Duracao = duracao;
        }

        public string Nome { get; set; }
        public int Duracao { get; set; }
        public List<DateTime> Secoes = new List<DateTime>();

        public override string ToString()
        {
            return Nome;
        }

        public void AdicionarSecao(DateTime horario)
        {
            Secoes.Add(horario);
        }
    }
}
