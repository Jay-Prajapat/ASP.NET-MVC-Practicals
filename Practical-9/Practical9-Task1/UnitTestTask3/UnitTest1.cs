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
            UnitTestController controller = new UnitTestController();
            var result = controller.Index();
            Assert.AreEqual(result, "Hello World");
        }
    }
}
