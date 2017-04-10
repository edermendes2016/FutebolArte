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
    public class TecnicoController : Controller
    {
        private FutebolContext db = new FutebolContext();
        public readonly RepositorioClube _RepositorioClube;
        private readonly RepositorioTecnico _repTecnico;

        public TecnicoController()
        {
            _RepositorioClube = new RepositorioClube();
            _repTecnico = new RepositorioTecnico();
        }

        // GET: Tecnico
        public ActionResult Index(Tecnico tecnico, string clube)
        {

            return View(_repTecnico.ObterTodos());
        }

        // GET: Tecnico/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = _repTecnico.ObterPorId(id.Value);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(Guid id)

        {
            
            Tecnico tecnico = _repTecnico.ObterPorId(id);
            var clube = tecnico.Clube.Id = tecnico.chvtecClube.Value;

            if (tecnico.Clube.GF>tecnico.Clube.GS)
            {
                tecnico.Clube.Pontos += 3;
                tecnico.Salario = (double.Parse(tecnico.Salario) + (double.Parse(tecnico.Salario) * 0.05)).ToString();
                _repTecnico.Atualizar(tecnico);
            }          


            return View(tecnico);
        }
        // GET: Tecnico/Create
        public ActionResult Create()
        {
            ViewBag.chvtecClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome");

            return View();
        }

        // POST: Tecnico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                ViewBag.chvtecClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome", tecnico.chvtecClube);
                _repTecnico.Adicionar(tecnico);
                return RedirectToAction("Index");
            }


            //ViewBag.chvtecJogo = new SelectList(db.Jogo, "Id", "Local", tecnico.chvtecJogo);
            return View(tecnico);
        }

        // GET: Tecnico/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = _repTecnico.ObterPorId(id.Value);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            ViewBag.chvtecClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome", tecnico.chvtecClube);

            return View(tecnico);
        }

        // POST: Tecnico/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tecnico tecnico)
        {
            if (ModelState.IsValid)
            {
                _repTecnico.Atualizar(tecnico);
                return RedirectToAction("Index");
            }
            ViewBag.chvtecClube = new SelectList(_RepositorioClube.ObterTodos(), "Id", "Nome", tecnico.chvtecClube);
            return View(tecnico);
        }

        // GET: Tecnico/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tecnico tecnico = _repTecnico.ObterPorId(id.Value);
            if (tecnico == null)
            {
                return HttpNotFound();
            }
            return View(tecnico);
        }

        // POST: Tecnico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _repTecnico.Remover(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repTecnico.Dispose();
                _RepositorioClube.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
