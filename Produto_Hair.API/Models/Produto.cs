namespace Produto_Hair.API.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public string Quantidade { get; set; }

        public Produto()
        {
        }

        public Produto(string nome, decimal valor, string quantidade)
        {
            this.Nome = nome;
            this.Valor = valor;
            this.Quantidade = quantidade;
        }
    }
}
