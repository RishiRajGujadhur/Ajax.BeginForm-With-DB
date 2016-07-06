using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    public class tblBlogsController : Controller
    {
        private wordocean1Entities db = new wordocean1Entities();

        // GET: tblBlogs
        public async Task<ActionResult> Index()
        {
            return View(await db.tblBlogs.ToListAsync());
        }

        // GET: tblBlogs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBlog tblBlog = await db.tblBlogs.FindAsync(id);
            if (tblBlog == null)
            {
                return HttpNotFound();
            }
            return View(tblBlog);
        }

        // GET: tblBlogs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblBlogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Title,Tags,PostedBy,Date,Content,Summary,PostID")] tblBlog tblBlog)
        {
            if (ModelState.IsValid)
            {
                db.tblBlogs.Add(tblBlog);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblBlog);
        }

        // GET: tblBlogs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBlog tblBlog = await db.tblBlogs.FindAsync(id);
            if (tblBlog == null)
            {
                return HttpNotFound();
            }
            return View(tblBlog);
        }

        // POST: tblBlogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Title,Tags,PostedBy,Date,Content,Summary,PostID")] tblBlog tblBlog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblBlog).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblBlog);
        }

        // GET: tblBlogs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblBlog tblBlog = await db.tblBlogs.FindAsync(id);
            if (tblBlog == null)
            {
                return HttpNotFound();
            }
            return View(tblBlog);
        }

        // POST: tblBlogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblBlog tblBlog = await db.tblBlogs.FindAsync(id);
            db.tblBlogs.Remove(tblBlog);
            await db.SaveChangesAsync();
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
