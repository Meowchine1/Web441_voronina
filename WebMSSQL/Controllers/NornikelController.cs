using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMSSQL.Models;
using System.Diagnostics;

namespace NorilskNikel.Controllers
{
    public class NornikelController : Controller
    {
       

        public IActionResult Index(int id)
        {
            ProjectContext db = new ProjectContext();
            ViewBag.Categories = db.categories_new.ToList();
        

            if (id == 0)
            {
                ViewBag.Resourses = db.resourses.ToList();
            }
            else
            {
                ViewBag.Resourses = db.resourses.Where(x => x.CategoryId == id).ToList();

            }

            return View();
        }

        public IActionResult Resourse(string id, string name, string message) {

            ProjectContext db = new ProjectContext();
            Resourses r = db.resourses.FirstOrDefault(x => x.path == id);
            if (r == null)
            {
                return NotFound();
            }

            ViewBag.Categories = db.categories_new.ToList();
            ViewBag.Resourse = r;

            return View();
           
        }   
        public IActionResult CategoryResourses(int id) {

            ProjectContext db = new ProjectContext();
            Categories category = db.categories_new.FirstOrDefault(x => x.Id == id); 
 
            if (category == null)
            {
                return NotFound();
            }

            ViewBag.Category = category;
            ViewBag.Categories = db.categories_new.ToList();
            ViewBag.Resourses = db.resourses.Where(x => x.CategoryId == id);

            return View();
           
        }  
        public IActionResult BuyProduct(int id) {

           

            return View();
           
        }
        [HttpPost]
        public IActionResult Search(string request) {

            if (request == null)
            {
                ProjectContext db = new ProjectContext();
                ViewBag.flag = false;
                ViewBag.Categories = db.categories_new.ToList();
            }
            else
            {
                ProjectContext db = new ProjectContext();

                var result = db.resourses.Where(x => x.name.ToLower().Contains(request.ToLower())).ToList();

                ViewBag.result = result;
                ViewBag.flag = (result.Count() != 0)? true : false ;
                ViewBag.Categories = db.categories_new.ToList();
            }

            return View();
           
        }

        public Resourses BestResourses()
        {
            ProjectContext db = new ProjectContext();
            Random rand = new Random();
            int toSkip = rand.Next(1, db.resourses.Count());

            return db.resourses.Skip(toSkip).Take(1).FirstOrDefault();
      
        }
      
    }
}