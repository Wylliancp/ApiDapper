using ApiDrapper.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDrapper.Tests.ValueObjects
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsNotValid()
        {
            var name = new Name("", "Costa");
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenNameIsValid()
        {
            var name = new Name("Wyllian", "Costa");
            Assert.AreEqual(true, name.IsValid);
            Assert.AreEqual(0, name.Notifications.Count);
        }


    }
}
