using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebMSSQL.Models;
using System.Diagnostics;

namespace NorilskNikel.Controllers
{
    public class NornikelController : Controller
    {

        public IActionResult Index(int categoryId)
        {

            ViewBag.Categories = DbData.GetCategories();
        

            if (categoryId == 0)
            {
                ViewBag.Resourses = DbData.GetResourses();
            }
            else
            {
                ViewBag.Resourses = DbData.GetResourses(categoryId);

            }

            return View();
        }


        public IActionResult Resourse(string pathId) {

            ProjectContext db = new ProjectContext();
            Resourses r = DbData.GetResourses(pathId);
            if (r == MockObjects.resourse)
            {
                return NotFound();
            }

            ViewBag.Categories = DbData.GetCategories();
            ViewBag.Resourse = r;

            return View();
           
        }   


        public IActionResult CategoryResourses(int categoryId) {

            ProjectContext db = new ProjectContext();
            Categories category = DbData.GetCategories(categoryId);
 
            if (category == MockObjects.category)
            {
                return NotFound();
            }

            ViewBag.Category = category;
            ViewBag.Categories = DbData.GetCategories();
            ViewBag.Resourses = DbData.GetResourses(categoryId);

            return View();
           
        }  


        public IActionResult BuyProduct(int id) {


            return View();
           
        }


        [HttpPost]
        public IActionResult Search(string request) {

            if (request == null)
            {
                ViewBag.flag = false;
                ViewBag.Categories = DbData.GetCategories();
            }
            else
            {
                var result = DbData.SearchResourses(request.ToLower());
                ViewBag.result = result;
                ViewBag.flag = (result.Count() != 0)? true : false ;
                ViewBag.Categories = DbData.GetCategories();
            }

            return View();
           
        }


        public Resourses BestResourses() => DbData.GetRandomResourse();
     

      
    }
}