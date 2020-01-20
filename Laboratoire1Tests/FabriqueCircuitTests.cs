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
    public class FabriqueCircuitTests
    {
        [TestMethod()]
        void ParseFromValeur()
        {
            String description = "(5.0,[4.0,(10,2)],8.0)";
            Composant c = FabriqueCircuit.fromString(description);
            c.MettreSousTension(9);
            Assert.AreEqual(16, c.CalculerResistance(), 0.1);
            Assert.AreEqual(0.5625, c.GetCourrant(), 0.001);
            Assert.AreEqual(9, c.GetTension(), 0.1);


            c = FabriqueCircuit.fromString("([100.000,250.0],[350.0//200.0])");
            c.MettreSousTension(9);
            Assert.AreEqual(198.70, c.CalculerResistance(), 0.1);
            Assert.AreEqual(0.04529, c.GetCourrant(), 0.001);
            Assert.AreEqual(9, c.GetTension(), 0.1);


            c = FabriqueCircuit.fromString("([([([([6.0,(2.0,10.0)],8.0),6.0],4.0),8.0],4.0),8.0]-6.0)");
            c.MettreSousTension(9);
            Assert.AreEqual(10, c.CalculerResistance(), 0.1);
            Assert.AreEqual(0.9, c.GetCourrant(), 0.01);
            Assert.AreEqual(9, c.GetTension(), 0.1);
        }


        void ParseMisformed()
        {
            Assert.ThrowsException<ArgumentException>(() => FabriqueCircuit.fromString(")"));
            Assert.ThrowsException<ArgumentException>(() => FabriqueCircuit.fromString("[)])"));
            Assert.ThrowsException<ArgumentException>(() => FabriqueCircuit.fromString("[)])])])"));
        }

        void ParseFromCode()
        {
            String description = "(NNVNA,[NNJNA,(NBNNA,NNRNA)],NNGNA)";
            Composant c = FabriqueCircuit.fromString(description);
            c.MettreSousTension(9);
            Assert.AreEqual(16, c.CalculerResistance(), 0.1);
            Assert.AreEqual(0.5625, c.GetCourrant(), 0.001);
            Assert.AreEqual(9, c.GetTension(), 0.1);


            c = FabriqueCircuit.fromString("([BNNNA,RVNNA],[OVNNA//RNNNA])");
            c.MettreSousTension(9);
            Assert.AreEqual(198.70, c.CalculerResistance(), 0.1);
            Assert.AreEqual(0.04529, c.GetCourrant(), 0.001);
            Assert.AreEqual(9, c.GetTension(), 0.1);

            c = FabriqueCircuit.fromString("([([([([NbNo,(NRNo,BNNo)],NGNo),NbNo],NNJNA),NGNA],NJNA),NNGNo]-NNbNA)");
            c.MettreSousTension(9);
            Assert.AreEqual(10, c.CalculerResistance(), 0.1);
            Assert.AreEqual(0.9, c.GetCourrant(), 0.01);
            Assert.AreEqual(9, c.GetTension(), 0.1);
        }
    }
}