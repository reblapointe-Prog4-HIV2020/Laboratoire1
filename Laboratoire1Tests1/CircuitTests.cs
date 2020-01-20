using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CegepJonquiere.RebLapointe.Laboratoire1;

namespace CegepJonquiere.RebLapointe.Laboratoire1.Tests
{
    [TestClass()]
    public class CircuitTests
    {
        [TestMethod()]
        public void MettreSousTensionTest()
        {
            Resistance[] res = new Resistance[10];
            res[0] = new Resistance(6);
            res[1] = new Resistance(8);
            res[2] = new Resistance(4);
            res[3] = new Resistance(8);
            res[4] = new Resistance(4);
            res[5] = new Resistance(6);
            res[6] = new Resistance(8);
            res[7] = new Resistance(10);
            res[8] = new Resistance(6);
            res[9] = new Resistance(2);

            Circuit[] circ = new Circuit[9];

            circ[0] = new CircuitSerie();
            circ[0].AddSousCircuit(res[9]);
            circ[0].AddSousCircuit(res[7]);

            circ[1] = new CircuitParallele();
            circ[1].AddSousCircuit(res[8]);
            circ[1].AddSousCircuit(circ[0]);

            circ[2] = new CircuitSerie();
            circ[2].AddSousCircuit(circ[1]);
            circ[2].AddSousCircuit(res[6]);

            circ[3] = new CircuitParallele();
            circ[3].AddSousCircuit(circ[2]);
            circ[3].AddSousCircuit(res[5]);

            circ[4] = new CircuitSerie();
            circ[4].AddSousCircuit(circ[3]);
            circ[4].AddSousCircuit(res[4]);

            circ[5] = new CircuitParallele();
            circ[5].AddSousCircuit(circ[4]);
            circ[5].AddSousCircuit(res[3]);

            circ[6] = new CircuitSerie();
            circ[6].AddSousCircuit(circ[5]);
            circ[6].AddSousCircuit(res[2]);

            circ[7] = new CircuitParallele();
            circ[7].AddSousCircuit(circ[6]);
            circ[7].AddSousCircuit(res[1]);

            circ[8] = new CircuitSerie();
            circ[8].AddSousCircuit(circ[7]);
            circ[8].AddSousCircuit(res[0]);

            circ[8].MettreSousTension(24);

            double[] resRes = { 6, 8, 4, 8, 4, 6, 8, 10, 6, 2 };
            double[] courrantRes = { 2.4, 1.2, 1.2, 0.6, 0.6, 0.4, 0.2, 0.0666, 0.1333, 0.0666 };
            double[] tensionRes = { 14.4, 9.6, 4.8, 4.8, 2.4, 2.4, 1.6, 0.666, 0.8, 0.1333 };

            double[] resCirc = { 12, 4, 12, 4, 8, 4, 8, 4, 10 };
            double[] courrantCirc = { 0.06666, 0.2, 0.2, 0.6, 0.6, 1.2, 1.2, 2.4, 2.4 };
            double[] tensionCirc = { 0.8, 0.8, 2.4, 2.4, 4.8, 4.8, 9.6, 9.6, 24 };

            for (int i = 0; i < res.Length; i++)
            {
                Assert.AreEqual(resRes[i], res[i].CalculerResistance(), 0.1);
                Assert.AreEqual(courrantRes[i], res[i].GetCourrant(), 0.1);
                Assert.AreEqual(tensionRes[i], res[i].GetTension(), 0.1);
            }

            for (int i = 0; i < circ.Length; i++)
            {
                Assert.AreEqual(resCirc[i], circ[i].CalculerResistance(), 0.1);
                Assert.AreEqual(courrantCirc[i], circ[i].GetCourrant(), 0.1);
                Assert.AreEqual(tensionCirc[i], circ[i].GetTension(), 0.1);
            }
        }

        [TestMethod()]
        public void MettreSousTensionIllegalTest()
        {
            Assert.ThrowsException<ArgumentException>(() => new Resistance(0));
            Assert.ThrowsException<ArgumentException>(() => new Resistance().SetValeur(0));
            Assert.ThrowsException<CircuitOuvertException>(() => new CircuitParallele().MettreSousTension(1));
            Assert.ThrowsException<CircuitOuvertException>(() => new CircuitSerie().MettreSousTension(1));
        }
        
        [TestMethod()]
        public void MettreSousTensionSerieTest()
        {
            Resistance[] res = new Resistance[4];
            res[0] = new Resistance(5);
            res[1] = new Resistance(4);
            res[2] = new Resistance(12);
            res[3] = new Resistance(8);

            double[] resRes = { 5, 4, 12, 8 };
            double[] courrantRes = { 0.827, 0.827, 0.827, 0.827 };
            double[] tensionRes = { 4.137, 3.31, 9.924, 6.616 };

            Circuit p = new CircuitSerie();
            foreach (Resistance r in res)
                p.AddSousCircuit(r);

            p.MettreSousTension(24);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(resRes[i], res[i].CalculerResistance(), 0.1);
                Assert.AreEqual(courrantRes[i], res[i].GetCourrant(), 0.1);
                Assert.AreEqual(tensionRes[i], res[i].GetTension(), 0.1);
            }

            Assert.AreEqual(29, p.CalculerResistance(), 0.1);
            Assert.AreEqual(0.827, p.GetCourrant(), 0.1);
            Assert.AreEqual(24, p.GetTension(), 0.1);
        }

        [TestMethod()]
        public void MettreSousTensionParalleleTest()
        {
            Resistance[] res = new Resistance[4];
            res[0] = new Resistance(5);
            res[1] = new Resistance(4);
            res[2] = new Resistance(12);
            res[3] = new Resistance(8);

            double[] resRes = { 5, 4, 12, 8 };
            double[] courrantRes = { 24, 30, 10, 15 };
            double[] tensionRes = { 120, 120, 120, 120 };

            Circuit p = new CircuitParallele();
            foreach (Resistance r in res)
                p.AddSousCircuit(r);

            p.MettreSousTension(120);

            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(resRes[i], res[i].CalculerResistance(), 0.1);
                Assert.AreEqual(courrantRes[i], res[i].GetCourrant(), 0.1);
                Assert.AreEqual(tensionRes[i], res[i].GetTension(), 0.1);
            }
            Assert.AreEqual(1.518, p.CalculerResistance(), 0.1);
            Assert.AreEqual(79.05, p.GetCourrant(), 0.1);
            Assert.AreEqual(120, p.GetTension(), 0.1);
        }
    }
}
