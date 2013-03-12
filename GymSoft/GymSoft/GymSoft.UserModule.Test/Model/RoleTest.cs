using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.UserModule.Model;
using NUnit.Framework;

namespace GymSoft.UserModule.Test.Model
{
    [TestFixture]
    public class RoleTest
    {
        #region SetUp / TearDown

        [SetUp]
        public void Init()
        { }

        [TearDown]
        public void Dispose()
        { }

        #endregion

        #region Tests

        [Test]
        public void RoleNameMustNotBeNull()
        {
            Role role = new Role { Name = "" };
            Assert.AreEqual("Role Name is required", role["Name"]);
        }

        #endregion
    }
}
