using Microsoft.AspNetCore.Mvc;
using WebMSSQL.Models;

namespace WebMSSQL.Controllers
{
    public class StartController : Controller
    {
        private ProjectContext db = new ProjectContext();

        public IActionResult startup() {
            return View();

        }

        public IActionResult CheckLogin(string login) {

            return Json(DbData.IsLoginFree(login));
        }

        public void singUp(string login, string password) {  // зарегистрироаться 

            
        }
       
    }
}
