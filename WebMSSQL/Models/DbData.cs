using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace WebMSSQL.Models
{
    public static class DbData
    {
       private static ProjectContext db = new ProjectContext();


        public static Resourses GetResourses(string id, string name, string message) {
            return db.resourses.FirstOrDefault(x => x.path == id, MockObjects.resourse);

        }
        public static List<Categories> GetCategories()
        {
            return db.categories_new.ToList();

        }

        public static bool IsLoginAlreadyExcist (string login)
        {

            User user = db.users.FirstOrDefault(x => x.Login == login, MockObjects.user);
            if (user != MockObjects.user)
            {
                return true;
            }
            else {
                return false;
            }

        }

        public static bool IsLoginFree(string login)
        {

            User user = db.users.FirstOrDefault(x => x.Login == login, MockObjects.user);
            if (user == MockObjects.user)
            {
                return true;
            }
            else
            {
                return false;
            }

        }



        public static bool Login(string login, string password)
        {
            if (IsLoginAlreadyExcist(login))
            {
            return HashPassword.Verify(db.users.FirstOrDefault(x => x.Login == login).PasswordHash, password);
            }

            return false;

        }


        public static bool Registration(string login, string password)
        {
            if (login.Trim().Length > 3)
            {

              
                return true;
            }
            return false;

        }

    }
}
