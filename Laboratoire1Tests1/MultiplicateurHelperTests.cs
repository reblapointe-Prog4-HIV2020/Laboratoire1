using Microsoft.VisualStudio.TestTools.UnitTesting;
using CegepJonquiere.RebLapointe.Laboratoire1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CegepJonquiere.RebLapointe.Laboratoire.Tests
{
    [TestClass()]
    public class MultiplicateurHelperTests
    {
        [TestMethod()]
        public void SymboleMultTest()
        {
            Assert.AreEqual("G", MultiplicateurHelper.SymboleMult(4_000_000_392L));
            Assert.AreEqual("M", MultiplicateurHelper.SymboleMult(1_000_000));
            Assert.AreEqual("k", MultiplicateurHelper.SymboleMult(999_999));
            Assert.AreEqual("", MultiplicateurHelper.SymboleMult(928));
            Assert.AreEqual("m", MultiplicateurHelper.SymboleMult(0.192));
            Assert.AreEqual("µ", MultiplicateurHelper.SymboleMult(0.000918));
            Assert.AreEqual("n", MultiplicateurHelper.SymboleMult(0.00000088219));
        }
        
    }
}