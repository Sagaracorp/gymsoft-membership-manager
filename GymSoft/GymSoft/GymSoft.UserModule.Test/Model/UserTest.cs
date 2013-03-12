using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.UserModule.Model;
using GymSoft.UserModule.Services;
using NUnit.Framework;

namespace GymSoft.UserModule.Test.Model
{
    [TestFixture]
    public class UserTest
    {
        #region SetUp / TearDown
        User validUser;

        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }

        [TestFixtureSetUp]
        public void FixtureInit()
        {
            validUser = new User
            {
                Id = 1,
                FirstName = "Rainaldo",
                LastName = "Crosbourne",
                EmailAddress = "rcrosbourne@gmail.com",
                UserName = "rcrosbourne@gmail.com"
            };
        }
        [TestFixtureTearDown]
        public void FixtureDispose()
        {
        }

        #endregion

        #region Tests

        [Test]
        public void FirstNameMustNotBeEmpty()
        {
            validUser.FirstName = "";
            Assert.AreEqual("First Name is required", validUser["FirstName"]);
        }
        [Test]
        public void LastNameMustNotBeEmpty()
        {
            validUser.LastName = "";
            Assert.AreEqual("Last Name is required", validUser["LastName"]);
        }
        [Test]
        public void EmailTests()
        {
            validUser.EmailAddress = "";
            Assert.AreEqual("Email Address is required", validUser["EmailAddress"]);
            validUser.EmailAddress = "rcrosbourne.@gmail.com";
            Assert.AreEqual("Email Address is in an incorrect format", validUser["EmailAddress"]);
            validUser.EmailAddress = "rcrosbourne@gmail.com";
            Assert.AreEqual("Email Address is already taken", validUser["EmailAddress"]);
        }
        [Test]
        public void UserNameTests()
        {
            validUser.UserName = "";
            Assert.AreEqual("User Name is required", validUser["UserName"]);
            validUser.UserName = "rcrosbourne@gmail.com";
            Assert.AreEqual("User Name already taken", validUser["UserName"]);

        }
        #region IsMemberOfRole and HasAccessToCommand
        [Test]
        public void UserIsMemberOfRole_Positive()
        {
            UserMockService userService = new UserMockService();
            User firstUser = userService.FindAll().First();
            Assert.IsTrue(userService.IsMemberOfRole(firstUser,"Admin"));
        }
        [Test]
        public void HasAccessToCommand_Positive()
        {
            UserMockService userService = new UserMockService();
            User firstUser = userService.FindAll().First();
            Assert.IsTrue(userService.HasAccessToCommand(firstUser, "View All Users"));
        }
        [Test]
        public void UserIsMemberOfRole_Negative()
        {
            UserMockService userService = new UserMockService();
            User firstUser = userService.FindAll().First();
            Assert.IsFalse(userService.IsMemberOfRole(firstUser, "Power Ranger"));
        }
        [Test]
        public void HasAccessToCommand_Negative()
        {
            UserMockService userService = new UserMockService();
            User firstUser = userService.FindAll().ElementAt(1);
            Assert.IsFalse(userService.HasAccessToCommand(firstUser, "Delete All Users"));
        }
        #endregion
        #endregion
    }
}