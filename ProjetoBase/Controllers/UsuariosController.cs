using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjetoBase.Data;
using ProjetoBase.Interface;
using ProjetoBase.Models;

namespace ProjetoBase.Controllers
{
    public class UsuariosController : Controller
    {
        private Contexto db = new Contexto();
        private readonly IUsuarioRepositorio _usuario;

        // GET: Usuarios
        public async Task<ActionResult> Index()
        {
            return View(await _usuario.GetAllAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View(await _usuario.GetByIdAsync(id));
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuario.Add(usuario);
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
           
            return View(await _usuario.GetByIdAsync(id));
        }

        // POST: Usuarios/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuario.Update(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            return View(await _usuario.GetByIdAsync(id));
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _usuario.Remove(id);
            return RedirectToAction("Index");
        }
        
    }
}
