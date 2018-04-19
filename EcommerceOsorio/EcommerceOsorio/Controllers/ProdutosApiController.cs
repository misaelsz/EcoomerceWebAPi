using EcommerceOsorio.DAL;
using EcommerceOsorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EcommerceOsorio.Controllers
{
    [RoutePrefix("api/Produtos")]
    public class ProdutosApiController : ApiController
    {
        //api/Produtos/Todos
        [Route("Todos")]
        public List<Produto> GetTodos()
        {
            return ProdutoDAO.ListarProdutos();
        }

        //api/Produtos/ProdutosPorCategoria/5
        [Route("ProdutosPorCategoria/{idCategoria}")]
        public List<Produto> GetProdutosPorCategoria(int? idCategoria)
        {
            return ProdutoDAO.ListarProdutosPorCategoria(idCategoria);
        }

        //api/Produtos/ProdutoPorId/2
        [Route("ProdutoPorId/{idProduto}")]
        public IHttpActionResult GetProdutoPorId(int? idProduto)
        {
            Produto p = ProdutoDAO.BuscarProdutoPorId(idProduto);
            if (p != null)
            {
                return Json(p);
            }
            else
            {
                return NotFound();
            }
        }

        //api/Produtos/ProdutoDinamico/2
        [Route("ProdutoDinamico/{idProduto}")]
        public dynamic GetProdutoDinamico(int? idProduto)
        {
            Produto p = ProdutoDAO.BuscarProdutoPorId(idProduto);
            dynamic produtoDinamico = new
            {
                Nome = p.ProdutoNome,
                Categoria = p.ProdutoCategoria.CategoriaNome,
                CategoriaObjeto = p.ProdutoCategoria,
                DataAtual = DateTime.Now.ToString("dd/MM/yyyy"),
                Autor = "Diogo"
            };
            return new { ObjetoProduto = produtoDinamico };
        }

    }
}
