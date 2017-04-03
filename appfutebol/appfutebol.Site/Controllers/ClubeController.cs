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
    public class ClubeController : Controller
    {
        //private FutebolContext db = new FutebolContext();
        public readonly RepositorioJogador _RepositorioJogador;
        public readonly RepositorioClube _RepositorioClube;

        public ClubeController()
        {
            _RepositorioClube = new RepositorioClube();
            _RepositorioJogador = new RepositorioJogador();
        }

        // GET: Clube
        public ActionResult Index()
        {
            return View(_RepositorioClube.ObterAtivos());
        }

        // GET: Clube/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clube clube = _RepositorioClube.ObterPorId(id.Value);
            if (clube == null)
            {
                return HttpNotFound();
            }
            return View(clube);
        }

        // GET: Clube/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clube/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Clube clube)
        {
            if (ModelState.IsValid)
            {
                _RepositorioClube.Adicionar(clube);
                return RedirectToAction("Index");
            }

            return View(clube);
        }

        // GET: Clube/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clube clube = _RepositorioClube.ObterPorId(id.Value);
            if (clube == null)
            {
                return HttpNotFound();
            }
            //ViewBag.chvTabela = new SelectList(db.Tabela, "Id", "Id", clube.chvTabela);
            return View(clube);
        }

        // POST: Clube/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Clube clube)
        {
            if (ModelState.IsValid)
            {
                _RepositorioClube.Atualizar(clube);
                return RedirectToAction("Index");
            }
   
            return View(clube);
        }

        // GET: Clube/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clube clube = _RepositorioClube.ObterPorId(id.Value);
            if (clube == null)
            {
                return HttpNotFound();
            }
            return View(clube);
        }

        // POST: Clube/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
           _RepositorioClube.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _RepositorioClube.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
