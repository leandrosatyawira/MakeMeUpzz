using MakeMeUpzz_UAS.Factory;
using MakeMeUpzz_UAS.Models;
using MakeMeUpzz_UAS.Modules;
using MakeMeUpzz_UAS.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MakeMeUpzz_UAS.Handler
{
    public class UserHandler
    {

        public static Response<List<User>> getAllUsers()
        {
                return new Response<List<User>>()
                {
                    Success = true,
                    Message = "Authorized!",
                    Payload = UsersRepository.GetAllUser()
                };
        }

        public static Response<User> getUserByID(int id)
        {
            User user = UsersRepository.GetUserByID(id);
            if (user == null)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "User not found!",
                    Payload = null
                };
            }
            else
            {
                return new Response<User>()
                {
                    Success = true,
                    Message = "User found!",
                    Payload = user
                };
            }
        }

        public static Response<User> register( String Username, String UserEmail, DateTime UserDOB, String UserGender, String UserRole, String UserPassword)
        {
            if (UsersRepository.GetUserByUsername(Username) != null)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Username already taken!",
                    Payload = null
                };
            }
            else
            {
                User user = UserFactory.Create(GenerateId(), Username, UserEmail, UserDOB, UserGender,UserRole, UserPassword);
                UsersRepository.AddUser(user);

                return new Response<User>()
                {
                    Success = true,
                    Message = "Register Success!",
                    Payload = user
                };
            }
        }

        private static int GenerateId()
        {
            User user = UsersRepository.GetLastUser();
            if (user == null)
            {
                return 1;
            }
            else
            {
                int userID = user.UserID + 1;
                return userID;
            }
        }

        public static Response<User> Login(String Username, String UserPassword)
        {
            User user = UsersRepository.GetUserByUsername(Username);
            if (user == null)
            {
                return new Response<User>()
                {
                    Success = false,
                    Message = "Username is not found",
                    Payload = null
                };
            }
            else
            {
                string storedPassword = user.UserPassword.Trim();
                string inputPassword = UserPassword.Trim();

                if (!storedPassword.Equals(inputPassword, StringComparison.Ordinal))
                {
                    return new Response<User>()
                    {
                        Success = false,
                        Message = "Invalid Credentials",
                        Payload = null
                    };
                }
                else
                {
                    return new Response<User>()
                    {
                        Success = true,
                        Message = "You have been logged in!",
                        Payload = user
                    };

                }
            }
        }

        public static Response<User> UpdateProfile(int UserID, string Username, String UserEmail, String UserGender, DateTime UserDOB)
        {
            UsersRepository.UpdatingUser(UserID, Username, UserEmail, UserGender, UserDOB);
            return new Response<User>()
            {
                Success = true,
                Payload = null
            };
        }

        public static Response<User> UpdatePass(int UserID, String Change_Pass1)
        {
            UsersRepository.ChangePasswordUser(UserID, Change_Pass1);
            return new Response<User>()
            {
                Success = true,
                Payload = null
            };
        }
    } 
}