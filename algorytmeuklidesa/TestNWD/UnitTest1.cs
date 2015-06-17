using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using algorytmeuklidesa;

namespace TestNWD
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test()
        {
            nwdclass nwd = new nwdclass();
            
            Assert.AreEqual(nwd.NWD(5, 10), 5, "Niepowodzenie przy nwd");
            //1 5 1 2 2
            Assert.AreEqual(nwd.NWD(1, 10), 1, "Niepowodzenie przy nwd");
            Assert.AreEqual(nwd.NWD(5, 125), 5, "Niepowodzenie przy nwd");
            Assert.AreEqual(nwd.NWD(10, 253), 1, "Niepowodzenie przy nwd");
            Assert.AreEqual(nwd.NWD(54, 250), 2, "Niepowodzenie przy nwd");
            Assert.AreEqual(nwd.NWD(124, 342), 2, "Niepowodzenie przy nwd");
        }
    }
}
