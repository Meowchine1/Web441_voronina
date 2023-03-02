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


        public static bool Login(string login, string password)
        {
            User user = db.users.FirstOrDefault(x => x.Login == login, MockObjects.user);

            if (user != MockObjects.user)
            {

                if (HashPassword.GetPasswordHash(password, user.Salt).Equals(user.PasswordHash))
                {
                    //залогинился
                }
                else
                {
                    // неверный пароль
                }
            }
            else 
            {
            // такого логина нет
            }

        }


        public static bool Registration(string login, string password)
        {
            if(login.Trim().Length >)

            string salt = HashPassword.GetSalt();
            string hashedPassword = HashPassword.GetPasswordHash(password, salt);
            User user = new User(login, hashedPassword, salt, UserRole.DEFAULT);


        }

    }
}
