using Produto_Hair.API.Services.Interfaces;
using Produto_Hair.API.Models;
using Produto_Hair.API.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Produto_Hair.API.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository repository;

        public ProdutoService(IProdutoRepository repository)
        {
            this.repository = repository;
        }
        public async Task<List<Produto>> BuscarPorTodos(string nome, decimal valor, string quantidade)
        {
            return await repository.BuscarPorTodos(nome, valor, quantidade);
        }
        public async Task<Produto> CriarProduto(Produto produto)
        {
            return await repository.CriarProduto(produto);
        }
        public async Task<Produto> BuscarPorId(int id)
        {
            return await this.repository.BuscarPorId(id);
        }
        public async Task AtualizarProdutoPorId(Produto produto)
        {
            await repository.AtualizarProdutoPorId(produto);
        }
        public async Task DeletarPorId(int id)
        {
            await repository.DeletarPorId(id);
        }


    }
}

