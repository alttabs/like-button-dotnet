using LikeButton.Models;
using LikeButton.Models.Classes;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LikeButton.Controllers
{
    public class LikesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Likes
        public ActionResult Index()
        {
            return View(db.Like.ToList());
        }

        public ActionResult Article(int? id)
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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "article_id,article_like,like_date,like_user")] Like like)
        {
            if (ModelState.IsValid)
            {
                like.article_id = 0;
                like.like_date = DateTime.Now;
                db.Like.Add(like);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(like);
        }

        public ActionResult LikePost(int id)
        {
            Like update = db.Like.ToList().Find(u => u.article_id == id);
            update.article_like += 1;
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
