using MakeMeUpzz_UAS.Factory;
using MakeMeUpzz_UAS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Repository
{
    public class UsersRepository
    {
        static MakeMeUpzzEntities db = DatabaseSingleton.GetInstance();

        public static List<User> GetAllUser()
        {
            return (from x in db.Users select x).ToList();
        }

        public static User GetUserByID(int id)
        {
            return (from x in db.Users where x.UserID == id select x).FirstOrDefault();
        }
        public static User GetUserByUsername(string username)
        {
            return (from x in db.Users where x.Username == username select x).FirstOrDefault();
        }

        public static void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static User GetLastUser()
        {
            //return (from x in db.Users select x.UserID).LastOrDefault();
            return db.Users.ToList().LastOrDefault();
        }

        public static void UpdatingUser(int id, String Usermame, String Email, String Gender, DateTime DOB)
        {
            User user = GetUserByID(id);
            user.Username = Usermame;
            user.UserEmail = Email;
            user.UserGender = Gender;
            user.UserDOB = DOB;
            db.SaveChanges();
        }
        public static void ChangePasswordUser(int id, String Password)
        {
            User user = GetUserByID(id);
            user.UserPassword = Password;
            db.SaveChanges();
        }
    }
}