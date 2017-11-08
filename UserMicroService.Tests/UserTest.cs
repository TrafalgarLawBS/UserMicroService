﻿using NUnit.Framework;
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
        public void CreateUserSuccess()
        {
            User testUser = new User
            {
                Id = 1,
                Name = "Marko"
            };
            UserDB.AddNewUser(testUser);
            Assert.AreEqual(1, UserDB.listOfUsers.Count);
        }
    }
}
