using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GymSoft.UserModule.Model;
using NUnit.Framework;

namespace GymSoft.UserModule.Test.Model
{
    [TestFixture]
    public class CommandTest
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
        public void CommandNameMustNotBeNull()
        {
            Command command = new Command
            {
                Name = ""
            };
            Assert.AreEqual("Command Name is required", command["Name"]);
        }
        #endregion
    }
}