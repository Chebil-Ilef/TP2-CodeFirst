using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP2.Models;

namespace TP2.Controllers
{
    public class GenreController : Controller
    {
        private readonly AppDbContext _db;
        public GenreController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.genres.ToList());
        }


        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Genre genre)
        {
            _db.genres.Add(genre);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Edit(Guid id)
        {
            // Récupérez le film à partir de la base de données en utilisant l'ID
            var genre = _db.genres.Find(id);

            if (genre == null)
            {
                return NotFound(); // Ou renvoyez une vue d'erreur personnalisée
            }

            return View(genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(genre).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genre);
        }

        public IActionResult Delete(Guid id)
        {
            var genre = _db.genres.Find(id);

            if (genre == null)
            {
                return NotFound();
            }

            return View(genre);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            var genre = _db.genres.Find(id);

            if (genre == null)
            {
                return NotFound(); // or handle as appropriate (e.g., redirect to a not found page)
            }

            _db.genres.Remove(genre);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult OnPost(Guid? id)
        {
            if (id == null) return NotFound();
            var m = _db.genres.FirstOrDefault(c => c.Id == id);
            return View(m);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnPost(Genre genre, Guid id)
        {
            var c = _db.genres.Find(id);
            c.Name = genre.Name;
            //_db.genres.Update(genre);
            try
            {   //breakpoints sur SaveChanges pour effectuer deux edit en 
                //Parrallèle --> Exécution du UPDATE 
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException db)
            {
                TempData["message"] = $"Cannot Add : {db.Message}";
                RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));

        }


    }
}
