using Microsoft.AspNetCore.Mvc;
using Projeto_PW.Models;
using System;
using System.Collections.Generic;

namespace Projeto_PW.Controllers
{
    public class ProdutosController : Controller
    {
        public static List<ProdutoModel> lsProdutos = new List<ProdutoModel>();

        public static List<CategoriaModel> lsCategorias = new List<CategoriaModel>();
        public IActionResult Index()
        {
          
            return View(lsProdutos);
        }

        public IActionResult Create()
        {
            
            ProdutoModel produto = new ProdutoModel();
            produto.Descricao = "Mouse Gamer";
            produto.Codigo = 10;
            produto.DataVencimento = DateTime.Now;
            ListagemCategorias();

            produto.ListaCategoriaDisponiveis = lsCategorias;
            
            
            
            return View(produto);
        }

        private List<CategoriaModel> ListagemCategorias()
        {
            CategoriaModel categoria1 = new CategoriaModel();
            categoria1.CategoriaId = 10;
            categoria1.Nome = "Periféricos";

            CategoriaModel categoria2 = new CategoriaModel();
            categoria2.CategoriaId = 20;
            categoria2.Nome = "Telofônia";

            CategoriaModel categoria3 = new CategoriaModel();
            categoria3.CategoriaId = 30;
            categoria3.Nome = "Acessórios";

            lsCategorias.Add(categoria1);
            lsCategorias.Add(categoria2);
            lsCategorias.Add(categoria3);
            return lsCategorias;
        }

        [HttpPost]
        public IActionResult Create(ProdutoModel produto)
        {
            lsProdutos.Add(produto);
            return RedirectToAction("Index");
        }
    }
}
