using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LikeButton.Models;
using LikeButton.Models.Classes;

namespace LikeButton.Controllers
{
    public class LikeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Like
        public ActionResult Index()
        {
            return View(db.Like.ToList());
        }

        // GET: Like/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Like like = db.Like.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
        }

        // GET: Like/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Like/Create
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "article_like,article_id,like_date,like_user")] Like like)
        {
            if (ModelState.IsValid)
            {
                like.article_like = 0;
                like.like_date = DateTime.Now;
                db.Like.Add(like);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(like);
        }

        // GET: Like/Edit/5

        public ActionResult Like(int id)
        {
           Like update= db.Like.ToList().Find(u=>)
            return RedirectToAction("Index");

        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Like like = db.Like.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
        }

        // POST: Like/Edit/5
        // Para proteger-se contra ataques de excesso de postagem, ative as propriedades específicas às quais deseja se associar. 
        // Para obter mais detalhes, confira https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "article_like,article_id,like_date,like_user")] Like like)
        {
            if (ModelState.IsValid)
            {
                db.Entry(like).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(like);
        }

        // GET: Like/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Like like = db.Like.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
        }

        // POST: Like/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Like like = db.Like.Find(id);
            db.Like.Remove(like);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
