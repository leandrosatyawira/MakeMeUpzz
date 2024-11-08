using MakeMeUpzz_UAS.Handler;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;

namespace MakeMeUpzz_UAS.Controller
{
    public class UserController
    {
        public static Response<User> Login(string username, string password)
        {
            if (username == "" || password == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "All fields must be filled!",
                    Payload = null
                };
            }
            else
            {
                return UserHandler.Login(username, password);
            }
        }

        public static Response<User> register(String Username, String UserEmail, DateTime UserDOB, String UserGender, String UserRole, String UserPassword, String Con_Pass)
        {
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            if (Username == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Username Cannot be Empty!",
                    Payload = null
                };
            }
            else if (Username.Length < 5 || Username.Length > 15)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Username must be between 5 - 15 characters",
                    Payload = null
                };
            }
            else if (!UserEmail.EndsWith(".com"))
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Email must end with '.com'!",
                    Payload = null
                };
            }
            else if (UserPassword == "" || Con_Pass == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Password Cannot be Empty!",
                    Payload = null
                };
            }
            else if (UserPassword != Con_Pass)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Password doesn't match",
                    Payload = null
                };
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(UserPassword, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"))
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Password must be at least 8 characters long and contain both letters and numbers.!",
                    Payload = null
                };
            }

            else if (UserGender == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Gender cannot be empty!",
                    Payload = null
                };
            }
            else if (UserDOB == DateTime.MinValue)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Please select your date of birth",
                    Payload = null
                };
            }
            else if (UserDOB > DateTime.Now)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "You cannot come from the future",
                    Payload = null
                };
            }
            else if (UserDOB > oneYearAgo)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "You must be older than 1 year old",
                    Payload = null
                };
            }

            return UserHandler.register( Username,  UserEmail,  UserDOB,  UserGender,  UserRole,  UserPassword);

        }

        public static Response<User> UpdateProfile(int UserID, String Username, String UserEmail, String UserGender, String UserDOB)
        {
            DateTime? dateUser = null;
            if (DateTime.TryParse(UserDOB.Trim(), out DateTime parsedDate))
            {
                dateUser = parsedDate;
            }
            DateTime oneYearAgo = DateTime.Now.AddYears(-1);
            if (Username == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "All Fields must be filled",
                    Payload = null
                };
            }
            else if (Username.Length < 5 || Username.Length > 15)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Username Length must be between 5 and 15 alphabet",
                    Payload = null
                };
            }
            else if (!UserEmail.EndsWith(".com"))
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Email must end with .com.",
                    Payload = null
                };
            }
            else if (UserGender == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Gender Cannot Be Empty",
                    Payload = null
                };
            }
            else if (dateUser == DateTime.MinValue)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Please select your date of birth",
                    Payload = null
                };
            }
            else if (dateUser > DateTime.Now)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "You can't be possibly come from the future",
                    Payload = null
                };
            }
            else if (dateUser > oneYearAgo)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "You must be at least 1 year old",
                    Payload = null
                };
            }
            return UserHandler.UpdateProfile(UserID, Username, UserEmail, UserGender, dateUser.Value);
        }

        public static Response<User> UpdatePass(String OldPass, String Change_Pass1, String Change_Pass2, User user)
        {
            if (OldPass == "" || Change_Pass1 == "" || Change_Pass2 == "")
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "All fields must be filled!",
                    Payload = null
                };

            }
            else if (OldPass != user.UserPassword.Trim())
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "The old password you entered does not match our records. Please try again.",
                    Payload = null
                };
            }
            else if (!System.Text.RegularExpressions.Regex.IsMatch(Change_Pass1, @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$"))
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Password must be at least 8 characters long and contain both letters and numbers.",
                    Payload = null
                };
            }
            else if (Change_Pass1 != Change_Pass2)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Change Passwords do not match! Please re-enter your new password.",
                    Payload = null
                };
            }

            return UserHandler.UpdatePass(user.UserID, Change_Pass1);

        }

        public static Response<List<User>> GetAllUsers()
        {
                return UserHandler.getAllUsers();
        }

        public static Response<User> getUserByID(int id)
        {
            return UserHandler.getUserByID(id);
        }
    }
}
