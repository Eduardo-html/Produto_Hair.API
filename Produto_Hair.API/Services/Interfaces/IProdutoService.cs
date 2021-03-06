using Produto_Hair.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produto_Hair.API.Services.Interfaces
{
    public interface IProdutoService
    {
        public Task<Produto> CriarProduto(Produto produto);
        public Task<List<Produto>> BuscarPorTodos(string nome_produto, decimal valor_produto, string quantidade_produto);
        public Task<Produto> BuscarPorId(int id);
        public Task AtualizarProdutoPorId(Produto produto);
        public Task DeletarPorId(int id);
    }
}