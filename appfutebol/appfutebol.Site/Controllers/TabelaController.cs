using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using appfutebol.Dominio;
using appfutebol.Repositorio.Infraestrutura;

namespace appfutebol.Site.Controllers
{
    public class TabelaController : Controller
    {
        //private FutebolContext db = new FutebolContext();
        private readonly RepositorioTabela _repTabela;
        public readonly RepositorioClube _RepositorioClube;
        public TabelaController()
        {
            _RepositorioClube = new RepositorioClube();
            _repTabela = new RepositorioTabela();
        }
            
        // GET: Tabela
        public ActionResult Index(string clube)
        {
            _RepositorioClube.Buscar(c => c.Nome == clube);
            return View(_repTabela.ObterTodos());
        }

        // GET: Tabela/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabela tabela = _repTabela.ObterPorId(id.Value);
            if (tabela == null)
            {
                return HttpNotFound();
            }
            return View(tabela);
        }

        // GET: Tabela/Create
        public ActionResult Create()
        {
            ViewBag.chvTabelaClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome");
            return View();
        }

        // POST: Tabela/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tabela tabela)
        {
            if (ModelState.IsValid)
            {
                _repTabela.Adicionar(tabela);
                return RedirectToAction("Index");
            }

            ViewBag.chvTabelaClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome", tabela.chvTabelaClube);
            return View(tabela);
        }

        // GET: Tabela/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabela tabela = _repTabela.ObterPorId(id.Value);
            if (tabela == null)
            {
                return HttpNotFound();
            }
            ViewBag.chvTabelaClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome", tabela.chvTabelaClube);
            return View(tabela);
        }

        // POST: Tabela/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tabela tabela)
        {
            if (ModelState.IsValid)
            {
                _repTabela.Atualizar(tabela);
                return RedirectToAction("Index");
            }
            ViewBag.chvTabelaClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome", tabela.chvTabelaClube);
            return View(tabela);
        }

        // GET: Tabela/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tabela tabela = _repTabela.ObterPorId(id.Value);
            if (tabela == null)
            {
                return HttpNotFound();
            }
            return View(tabela);
        }

        // POST: Tabela/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _repTabela.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _RepositorioClube.Dispose();
                _repTabela.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
