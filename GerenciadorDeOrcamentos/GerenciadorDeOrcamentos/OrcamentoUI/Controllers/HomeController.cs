using OrcamentoData;
using OrcamentoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrcamentoUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        #region Categorias
        public ActionResult IndexCategorias()
        {
            var cat = CategoriasRepository.GetAll();
            return View(cat);
        }

        [HttpGet]
        public ActionResult CreateCategorias()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCategorias(Categorias Categoria)
        {
            CategoriasRepository nova = new CategoriasRepository();
            nova.Create(Categoria);
            return RedirectToAction("IndexCategorias");
        }

        [HttpGet]
        public ActionResult EditCategorias(int pIdCategoria)
        {
            var cat = CategoriasRepository.GetOne(pIdCategoria);
            return View(cat);
        }

        [HttpPost]
        public ActionResult EditCategorias(Categorias Categoria)
        {
            CategoriasRepository edit = new CategoriasRepository();
            edit.Edit(Categoria);
            return RedirectToAction("IndexCategorias");
        }

        [HttpGet]
        public ActionResult DeleteCategorias(int pIdCategoria)
        {
            var cat = CategoriasRepository.GetOne(pIdCategoria);
            return View(cat);
        }

        [HttpPost]
        public ActionResult DeleteCategorias(Categorias pCategoria)
        {
            CategoriasRepository del = new CategoriasRepository();
            del.Delete(pCategoria.IdCategoria);
            return RedirectToAction("IndexCategoria");
        }
        #endregion

        #region Clientes
        public ActionResult IndexClientes()
        {
            var cli = ClientesRepository.GetAll();
            return View(cli);
        }

        [HttpGet]
        public ActionResult CreateClientes()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateClientes(Clientes Cliente)
        {
            ClientesRepository nova = new ClientesRepository();
            nova.Create(Cliente);
            return RedirectToAction("IndexClientes");
        }

        [HttpGet]
        public ActionResult EditClientes(int pIdCliente)
        {
            var cli = ClientesRepository.GetOne(pIdCliente);
            return View(cli);
        }

        [HttpPost]
        public ActionResult EditClientes(Clientes Cliente)
        {
            ClientesRepository edit = new ClientesRepository();
            edit.Edit(Cliente);
            return RedirectToAction("IndexClientes");
        }

        [HttpGet]
        public ActionResult DeleteClientes(int pIdCliente)
        {
            var cli = ClientesRepository.GetOne(pIdCliente);
            return View(cli);
        }

        [HttpPost]
        public ActionResult DeleteClientes(Clientes Cliente)
        {
            ClientesRepository del = new ClientesRepository();
            del.Delete(Cliente.IdCliente);
            return RedirectToAction("IndexCliente");
        }
        #endregion

        #region Orcamentos
        public ActionResult IndexOrcamentos()
        {
            var orc = OrcamentosRepository.GetAll();
            return View(orc);
        }

        public ActionResult IniciarOrcamentos()
        {
            int IdOrcamento = OrcamentosRepository.CreateFirst();
            return RedirectToAction("CreateOrcamentos", new { id = IdOrcamento });
        }

        [HttpGet]
        public ActionResult CreateOrcamentos(int id)
        {
            ViewBag.Clientes = new SelectList(ClientesRepository.GetAll(), "IdCliente", "NomeCliente");
            ViewBag.Produtos = new SelectList(ProdutosRepository.GetAll(), "IdProduto", "NomeProduto");
            ViewBag.OrcProd = OrcamentosProdutosRepository.GetAll();
            ViewBag.IdOrcamento = id;
            return View();
        }

        [HttpPost]
        public ActionResult CreateOrcamentos(Orcamentos Orcamento)
        {
            OrcamentosRepository nova = new OrcamentosRepository();
            nova.Create(Orcamento);
            return RedirectToAction("IndexOrcamentos");
        }

        [HttpGet]
        public ActionResult EditOrcamentos(int pIdOrcamento)
        {
            var orc = OrcamentosRepository.GetOne(pIdOrcamento);
            return View(orc);
        }

        [HttpPost]
        public ActionResult EditOrcamentos(Orcamentos Orcamento)
        {
            OrcamentosRepository edit = new OrcamentosRepository();
            edit.Edit(Orcamento);
            return RedirectToAction("IndexOrcamentos");
        }

        [HttpGet]
        public ActionResult DeleteOrcamentos(int pIdOrcamento)
        {
            var orc = ClientesRepository.GetOne(pIdOrcamento);
            return View(orc);
        }

        [HttpPost]
        public ActionResult DeleteOrcamentos(Orcamentos Orcamento)
        {
            OrcamentosRepository del = new OrcamentosRepository();
            del.Delete(Orcamento.IdOrcamento);
            return RedirectToAction("IndexOrcamento");
        }
        #endregion

        #region OrcamentosProdutos

        [HttpGet]
        public ActionResult AddProdutos()
        {
            ViewBag.Produtos = new SelectList(ProdutosRepository.GetAll(), "IdProduto", "NomeProduto");
            return View();
        }

        [HttpPost]
        public ActionResult AddProdutos(OrcamentosProdutos OrcProd)
        {
            int IdOrcamento = OrcamentosProdutosRepository.Create(OrcProd);
            return RedirectToAction("CreateOrcamentos", new { id = IdOrcamento });
        }

        [HttpGet]
        public ActionResult ExcluirProduto(int pIdOrcamento, int pIdProduto)
        {
            var orcprod = OrcamentosProdutosRepository.GetOne(pIdOrcamento, pIdProduto);
            return View(orcprod);
        }

        [HttpPost]
        public ActionResult ExcluirProduto(Orcamentos Orcamento, Produtos Produto)
        {
            OrcamentosProdutosRepository del = new OrcamentosProdutosRepository();
            del.Delete(Orcamento.IdOrcamento, Produto.IdProduto);
            return RedirectToAction("CreateOrcamentos");
        }
        #endregion

        #region Produtos
        public ActionResult IndexProdutos()
        {
            var prod = ProdutosRepository.GetAll();
            return View(prod);
        }

        [HttpGet]
        public ActionResult CreateProdutos()
        {
            ViewBag.Categorias = new SelectList(CategoriasRepository.GetAll(), "IdCategoria", "NomeCategoria");
            ViewBag.Unidades = new SelectList(UnidadesRepository.GetAll(), "IdUnidade", "Sigla");
            return View();
        }

        [HttpPost]
        public ActionResult CreateProdutos(Produtos Produto)
        {
            ProdutosRepository nova = new ProdutosRepository();
            nova.Create(Produto);
            return RedirectToAction("IndexProdutos");
        }

        [HttpGet]
        public ActionResult EditProdutos(int pIdProduto)
        {
            var prod = ProdutosRepository.GetOne(pIdProduto);
            ViewBag.Categorias = new SelectList(CategoriasRepository.GetAll(), "IdCategoria", "NomeCategoria");
            ViewBag.Unidades = new SelectList(UnidadesRepository.GetAll(), "IdUnidade", "Sigla");
            return View(prod);
        }

        [HttpPost]
        public ActionResult EditProdutos(Produtos Produto)
        {
            ProdutosRepository edit = new ProdutosRepository();
            edit.Edit(Produto);
            return RedirectToAction("IndexProdutos");
        }

        [HttpGet]
        public ActionResult DeleteProdutos(int pIdProduto)
        {
            var prod = ProdutosRepository.GetOne(pIdProduto);
            return View(prod);
        }

        [HttpPost]
        public ActionResult DeleteProdutos(Produtos Produto)
        {
            ProdutosRepository del = new ProdutosRepository();
            del.Delete(Produto.IdProduto);
            return RedirectToAction("IndexProdutos");
        }
        #endregion

        #region Unidades
        public ActionResult IndexUnidades()
        {
            var unid = UnidadesRepository.GetAll();
            return View(unid);
        }

        [HttpGet]
        public ActionResult CreateUnidades()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUnidades(Unidades Unidade)
        {
            UnidadesRepository nova = new UnidadesRepository();
            nova.Create(Unidade);
            return RedirectToAction("IndexUnidades");
        }

        [HttpGet]
        public ActionResult EditUnidades(int pIdUnidade)
        {
            var unid = UnidadesRepository.GetOne(pIdUnidade);
            return View(unid);
        }

        [HttpPost]
        public ActionResult EditUnidades(Unidades Unidade)
        {
            UnidadesRepository edit = new UnidadesRepository();
            edit.Edit(Unidade);
            return RedirectToAction("IndexUnidades");
        }

        [HttpGet]
        public ActionResult DeleteUnidades(int pIdUnidade)
        {
            var unid = UnidadesRepository.GetOne(pIdUnidade);
            return View(unid);
        }

        [HttpPost]
        public ActionResult DeleteUnidades(Unidades Unidade)
        {
            UnidadesRepository del = new UnidadesRepository();
            del.Delete(Unidade.IdUnidade);
            return RedirectToAction("IndexUnidades");
        }
        #endregion
    }
}
