using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using achievement.Models;
using achievement.DAL;

namespace achievement.Controllers
{
    public class AchievementController : Controller
    {
        private AchievementContext db = new AchievementContext();

        // GET: /Achievement/
        public async Task<ActionResult> Index()
        {
            var achievements = from s in db.Achievements
                               select s;
            
           achievements= achievements.OrderByDescending(s => s.Created)
                .Take(100);
          
            return View(await achievements.ToListAsync());
        }
        
        // GET: /Achievement/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = await db.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // GET: /Achievement/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Achievement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> Create([Bind(Include="ID,Name,Acheivement,Created,Createdby,URL")] Achievement achievement)
        {
            if (ModelState.IsValid)
            {
                achievement.Created = DateTime.Now;
                achievement.Createdby = User.Identity.Name;
                db.Achievements.Add(achievement);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(achievement);
        }

        // GET: /Achievement/Edit/5
         [Authorize]
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = await db.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // POST: /Achievement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = await db.Achievements.FindAsync(id);


            if (TryUpdateModel(achievement, "",
       new string[] { "Name", "URL", "Acheivement" }))
            {
                try
                {
                    db.Entry(achievement).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(achievement);
        }

        // GET: /Achievement/Delete/5
         [Authorize]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Achievement achievement = await db.Achievements.FindAsync(id);
            if (achievement == null)
            {
                return HttpNotFound();
            }
            return View(achievement);
        }

        // POST: /Achievement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Achievement achievement = await db.Achievements.FindAsync(id);
            db.Achievements.Remove(achievement);
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
