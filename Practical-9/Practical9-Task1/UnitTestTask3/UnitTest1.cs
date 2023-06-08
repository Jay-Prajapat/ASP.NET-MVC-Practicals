using Microsoft.VisualStudio.TestTools.UnitTesting;
using Practical9_Task1.Controllers;
using System;

namespace UnitTestTask3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestHelloMessage()
        {
            Task3Controller controller = new Task3Controller();
            var result = controller.Index();
            Assert.AreEqual(result, "Hello World");
        }
    }
}
