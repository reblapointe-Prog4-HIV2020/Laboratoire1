using Microsoft.VisualStudio.TestTools.UnitTesting;
using Laboratoire1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratoire1.Tests
{
    [TestClass()]
    public class FabriqueResistanceTests
    {
        [TestMethod()]
        public void FromCodeTest()
        {
            Assert.AreEqual(270, FabriqueResistance.FromCode("RMBo").GetValeur());
            Assert.AreEqual(0.05, FabriqueResistance.FromCode("RMBo").GetTolerance());
            Assert.AreEqual(270, FabriqueResistance.FromCode("RMNNA").GetValeur());
            Assert.AreEqual(0.1, FabriqueResistance.FromCode("RMNNA").GetTolerance());
            Assert.AreEqual(100000, FabriqueResistance.FromCode("BNNOB").GetValeur());
            Assert.AreEqual(274, FabriqueResistance.FromCode("RMJNR").GetValeur());
            Assert.AreEqual(1200000, FabriqueResistance.FromCode("BRVo").GetValeur());
            Assert.AreEqual(10000, FabriqueResistance.FromCode("BNNRB").GetValeur());
            Assert.AreEqual(35.2, FabriqueResistance.FromCode("OVRoo").GetValeur());
            Assert.ThrowsException<ArgumentException>(() => FabriqueResistance.FromCode(""));
            Assert.ThrowsException<ArgumentException>(() => FabriqueResistance.FromCode("NoNono"));
        }
    }
}