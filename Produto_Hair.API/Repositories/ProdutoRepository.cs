using Dapper;
using Produto_Hair.API.Models;
using Produto_Hair.API.Repositories.Interfaces;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Produto_Hair.API.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private static List<Produto> produto { get; set; } = new List<Produto>();

        public async Task<List<Produto>> BuscarPorTodos(string nome, decimal valor, string quantidade)
        {
            var listaProduto = new List<Produto>();
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-5VNS708; Initial Catalog=ProdutoHair; Integrated Security=true"))
            {
                var produtoResult = await connection.QueryAsync<Produto>("SELECT * FROM  dbo.Cadastro_Hair WHERE (@nome is null or nome = @nome) AND (@valor = 0 or valor = @valor) AND (@quantidade is null or quantidade = @quantidade)", new { nome, valor, quantidade });
                listaProduto = produtoResult.ToList();
            }
            return listaProduto;
        }
        public async Task<Produto> CriarProduto(Produto produto)
        {
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-5VNS708; Initial Catalog=ProdutoHair; Integrated Security=true"))
            {
                var listaProduto = new List<Produto>();
                var resultado = await connection.QueryAsync<Produto>(@"INSERT INTO Cadastro_Hair (Nome, Valor, Quantidade)VALUES(@nome, @valor, @quantidade)", new { nome = produto.Nome, valor = produto.Valor, quantidade = produto.Quantidade.ToString() });

                listaProduto = resultado.ToList();
            }
            return produto;
        }
        public async Task<Produto> BuscarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-5VNS708; Initial Catalog=ProdutoHair; Integrated Security=true"))
            {
                return await connection.QueryFirstOrDefaultAsync<Produto>("SELECT * FROM dbo.Cadastro_Hair WHERE Id = @id", new { id });
            }
        }
        public async Task AtualizarProdutoPorId(Produto produto)
        {
            var produtoEntity = await this.BuscarPorId(produto.Id);

            if (!string.IsNullOrEmpty(produto.Nome))
                produtoEntity.Nome = produto.Nome;
            if (produto.Valor != 0)
                produtoEntity.Valor = produto.Valor;
            if (!string.IsNullOrEmpty(produto.Quantidade))
                produtoEntity.Quantidade = produto.Quantidade;

            ;
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-5VNS708; Initial Catalog=ProdutoHair; Integrated Security=true"))
            {
                var listaProduto = new List<Produto>();
                var resultado = await connection.ExecuteAsync(@"UPDATE Cadastro_Hair SET Nome = @nome , Valor = @valor, Quantidade = @quantidade WHERE Id = @id", new { id = produtoEntity.Id, nome = produtoEntity.Nome, valor = produtoEntity.Valor, quantidade = produtoEntity.Quantidade.ToString() });
            }
        }

        public async Task DeletarPorId(int id)
        {
            using (SqlConnection connection = new SqlConnection(@"Server=DESKTOP-5VNS708; Initial Catalog=ProdutoHair; Integrated Security=true"))
            {
                var listaProduto = new List<Produto>();
                var resultado = await connection.QueryAsync<Produto>(@"DELETE FROM Cadastro_Hair WHERE Id = @id", new { id = id });
                listaProduto = resultado.ToList();
            }
        }
    }

}
