using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Produto_Hair.API.Models;
using Produto_Hair.API.Services.Interfaces;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Produto_Hair.API.Controllers
{
    [EnableCors("CorsApi")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService service;
        public ProdutoController(IProdutoService service)
        {
            this.service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string nome, [FromQuery] decimal valor, [FromQuery] string quantidade)
        {
            try
            {
                var result = await this.service.BuscarPorTodos(nome, valor, quantidade);
                return StatusCode((int)HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Produto produto)
        {
            try
            {

                await service.CriarProduto(produto);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Produto produto)
        {
            try
            {
                produto.Id = id;
                await service.AtualizarProdutoPorId(produto);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            try
            {
                await service.DeletarPorId(id);
                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}

