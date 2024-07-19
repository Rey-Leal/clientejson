using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public class Produto
    {
        Produto() { }

        public Produto(int id, string nome, string categoria, decimal preco)
        {
            this.Id = id;
            this.Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            this.Categoria = categoria ?? throw new ArgumentNullException(nameof(categoria));
            this.Preco = preco;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Categoria { get; set; }
        public decimal Preco { get; set; }
    }
}
