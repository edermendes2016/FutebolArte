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
    public class JogadorController : Controller
    {
        private FutebolContext db = new FutebolContext();
        public readonly RepositorioJogador _RepositorioJogador;
        public readonly RepositorioClube _RepositorioClube;

        public JogadorController()
        {
            _RepositorioClube = new RepositorioClube();
            _RepositorioJogador = new RepositorioJogador();
        }
        // GET: Jogador
        public ActionResult Index()
        {
            return View(_RepositorioJogador.ObterTodos());
        }

      
      
        // GET: Jogador/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = _RepositorioJogador.ObterPorId(id.Value);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        // GET: Jogador/Create
        public ActionResult Create()
        {
            ViewBag.chvClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome");

            return View();
        }

        // POST: Jogador/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                _RepositorioJogador.Adicionar(jogador);
                return RedirectToAction("Index");
            }

            ViewBag.chvClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome", jogador.chvClube);

            return View(jogador);
        }

        // GET: Jogador/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = _RepositorioJogador.ObterPorId(id.Value);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            ViewBag.chvClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome", jogador.chvClube);
            return View(jogador);
        }

        // POST: Jogador/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                _RepositorioJogador.Atualizar(jogador);
                return RedirectToAction("Index");
            }
            ViewBag.chvClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome", jogador.chvClube);
            return View(jogador);
        }

        // GET: Jogador/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogador jogador = _RepositorioJogador.ObterPorId(id.Value);
            if (jogador == null)
            {
                return HttpNotFound();
            }
            return View(jogador);
        }

        // POST: Jogador/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _RepositorioJogador.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _RepositorioJogador.Dispose();
                _RepositorioClube.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
