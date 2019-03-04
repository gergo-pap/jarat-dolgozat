using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repulo.Tests
{
    [TestFixture]
    public class TestJaratkezelo
    {
        JaratKezelo jaratKezelo;
        Jarat jarat;

        [SetUp]
        public void setUp()
        {
            jaratKezelo = new JaratKezelo();
        }

        [Test]
        public void UjJaratSzamTest()
        {
            Jarat jaratTest = new Jarat("2", "Bp", "Bigga", new DateTime(2019,3,10,14,8,0));
            Assert.AreEqual("2", jaratTest.JaratSzam);
        }

        [Test]
        public void UjJaratrepterHonnanTest()
        {
            Jarat jaratTest = new Jarat("2", "Bp", "Bigga", new DateTime(2019, 3, 10, 14, 8, 0));
            Assert.AreEqual("Bp", jaratTest.HonnanRepter);
        }

        [Test]
        public void UjJaratrepterHovaTest()
        {
            Jarat jaratTest = new Jarat("2", "Bp", "Bigga", new DateTime(2019, 3, 10, 14, 8, 0));
            Assert.AreEqual("Bigga", jaratTest.HovaRepter);
        }
        
        [Test]
        public void UjJaratindulasTest()
        {
            Jarat jaratTest = new Jarat("2", "Bp", "Bigga", new DateTime(2019, 3, 10, 14, 8, 0));
            Assert.AreEqual(new DateTime(2019, 3, 10, 14, 8, 0), jaratTest.Indulas);
        }
        
        [Test]
        public void KesesTest()
        {
            jaratKezelo.UjJarat("2", "Bp", "Bigga", new DateTime(2019, 3, 10, 14, 8, 0));
            jaratKezelo.Keses("2",15);//több,negativ,summa negativ
            Assert.AreEqual(new DateTime(2019, 3, 10, 14, 23, 0), jaratKezelo.MikorIndul("2"));
            
        }
        [Test]
        public void KesesTobbTest()
        {
            jaratKezelo.UjJarat("2", "Bp", "Bigga", new DateTime(2019, 3, 10, 14, 10, 0));
            jaratKezelo.Keses("2", 15);
            jaratKezelo.Keses("2", 30);
            Assert.AreEqual(new DateTime(2019, 3, 10, 14, 55, 0), jaratKezelo.MikorIndul("2"));

        }
        [Test]
        public void KesesNegativTest()
        {
            jaratKezelo.UjJarat("2", "Bp", "Bigga", new DateTime(2019, 3, 10, 14, 10, 0));
            jaratKezelo.Keses("2", 15);
            
            Assert.Throws<NegatvKesesExcepton>(
                () =>
                {
                    jaratKezelo.Keses("2", -20);
                }
            );

        }
        [Test]
        public void MikorIndulTest()
        {
            jaratKezelo.UjJarat("2", "Bp", "Bigga", new DateTime(2019, 3, 10, 14, 8, 0));
            Assert.AreEqual(new DateTime(2019, 3, 10, 14, 8, 0), jaratKezelo.MikorIndul("2"));
        }

        [Test]
        public void KetJaratUANevTest()
        {
            jaratKezelo.UjJarat("2", "Bp", "Bigga", new DateTime(2019, 3, 10, 14, 8, 0));
            
            Assert.Throws<ArgumentException>(
                () =>
                {
                    jaratKezelo.UjJarat("2", "Bp", "Bigga", new DateTime(2019, 3, 10, 14, 8, 0));
                }
            );

        }

    }
}
