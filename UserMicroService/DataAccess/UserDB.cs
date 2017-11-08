using System;
using System.Collections.Generic;
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
            listOfUsers.Add(user);
            return GetUserById(user.Id);
        }

        public static void ModifyUser(User u) {

            User user = GetUserById(u.Id);

            listOfUsers.Remove(user);
            listOfUsers.Add(u);            
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