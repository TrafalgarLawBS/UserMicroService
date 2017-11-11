using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using UserMicroService.Models;

namespace UserMicroService.DataAccess
{
    public static class UserDB
    {
        public static List<User> listOfUsers = new List<User>();


        public static User GetUserById(int id) {
            foreach (User u in listOfUsers) {
                if (u.Id == id) {
                    return u;
                }
            }
            return null;
        }

        public static User GetUserByName(string name) {
            foreach (User u in listOfUsers)
            {
                if (u.Name == name)
                {
                    return u;
                }
            }
            return null;
        }

        public static List<User> GetAllUsers() {
            return listOfUsers;
        }

        public static User AddNewUser(User user) {
            foreach (User u in listOfUsers)
            {
                if (u.Id == user.Id) {
                    Debug.WriteLine("User with this id already exists in database : /n {0}", u.ToString());

                    return u;
                }
            }
            listOfUsers.Add(user);
            Debug.WriteLine("User: {0} successfully added to database /n", user.ToString());
            return GetUserById(user.Id);
        }

        public static void ModifyUser(User u) {

            User user = GetUserById(u.Id);
            if (user != null) {
                listOfUsers.Remove(user);
                listOfUsers.Add(u);
            }
                        
        }

        public static void DeleteUser(int id) {
            User user = GetUserById(id);
            if (user != null)
            {
                listOfUsers.Remove(user);
            }
        }

    }
}