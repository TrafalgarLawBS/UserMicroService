using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMicroService.DataAccess;
using UserMicroService.Models;

namespace UserMicroService.Tests
{
    class UserTest
    {
        public void ClearUsers()
        {
            UserDB.listOfUsers.Clear();
        }


        [Test]
        public void Create_User_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"                
            };
            UserDB.AddNewUser(testUser);
            Assert.AreEqual(1, UserDB.listOfUsers.Count);
        }

        [Test]
        public void Create_User_Fail()
        {
            ClearUsers();
            User testUser1 = new User
            {
                Id = 1,
                Name = "Marko"
            };
            User testUser2 = new User
            {
                Id =1,
                Name = "Sinisa"
            };
            UserDB.AddNewUser(testUser1);
            UserDB.AddNewUser(testUser2);
            Assert.AreEqual(1, UserDB.listOfUsers.Count);
        }

        [Test]
        public void Search_User_By_ID_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"
            };
            UserDB.AddNewUser(testUser);

            Assert.AreEqual(testUser, UserDB.GetUserById(1));
        }

        [Test]
        public void Search_User_By_ID_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"
            };
            UserDB.AddNewUser(testUser);

            Assert.AreEqual(null, UserDB.GetUserById(2));
        }

        [Test]
        public void Search_User_By_Name_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"
            };
            UserDB.AddNewUser(testUser);

            Assert.AreEqual(testUser, UserDB.GetUserByName("Marko"));
        }

        [Test]
        public void Search_User_By_Name_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"
            };
            UserDB.AddNewUser(testUser);

            Assert.AreEqual(null, UserDB.GetUserByName("Sinisa"));
        }

        [Test]
        public void Get_All_Users_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"
            };
            UserDB.AddNewUser(testUser);

            Assert.AreEqual(1, UserDB.GetAllUsers().Count);
        }

        [Test]
        public void Modify_User_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"
            };
            UserDB.AddNewUser(testUser);

            User testUser1 = new User
            {
                Id = 1,
                Name = "Sinisa"
            };

            UserDB.ModifyUser(testUser1);

            Assert.AreEqual(testUser1, UserDB.GetUserByName("Sinisa"));
        }

        [Test]
        public void Modify_User_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"
            };
            UserDB.AddNewUser(testUser);

            User testUser1 = new User
            {
                Id = 1,
                Name = "Sinisa"
            };

            UserDB.ModifyUser(testUser1);

            Assert.AreEqual(null, UserDB.GetUserByName("Marko"));
        }

        [Test]
        public void Delete_User_Success()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"
            };
            UserDB.AddNewUser(testUser);
            UserDB.DeleteUser(1);

            Assert.AreEqual(0, UserDB.listOfUsers.Count);
        }

        [Test]
        public void Delete_User_Fail()
        {
            ClearUsers();
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"
            };
            UserDB.AddNewUser(testUser);
            UserDB.DeleteUser(2);

            Assert.AreEqual(1, UserDB.listOfUsers.Count);
        }

    }
}
