using Microsoft.VisualStudio.TestTools.UnitTesting;
using DiagramLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramLibrary.Models.Tests
{
    [TestClass()]
    public class DiagramOpgaveTests
    {
        private Opgave opgave1 = new Opgave { ID = 0, Omschrijving = "Opgave 1", Oplossing = "ABCD" };
        private Opgave opgave2 = new Opgave { ID = 1, Omschrijving = "Opgave 2", Oplossing = "ABCD" };
        private Opgave opgaveLang = new Opgave { ID = 1, Omschrijving = "Opgave Lang", Oplossing = "123456789" };


        [TestMethod()]
        public void OverlapIdentiekStartpuntLegeOpgave2Test()
        {
            // Assign

            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };
            var diagramOpgave2 = new DiagramOpgave { Opgave = null, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };

            // Act

            // Assert
            Assert.IsTrue(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void OverlapIdentiekStartpuntLegeOpgave1Test()
        {
            // Assign

            var diagramOpgave1 = new DiagramOpgave { Opgave = null, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };

            // Act

            // Assert
            Assert.IsTrue(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void OverlapIdentiekStartpuntHorizontaalTest()
        {
            // Assign

            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };

            // Act

            // Assert
            Assert.IsFalse(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void OverlapIdentiekStartpuntVerticaalTest()
        {
            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 1) };
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 1) };

            // Act

            // Assert
            Assert.IsFalse(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void OverlapIdentiekStartpuntAndereRichtingTest()
        {
            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 1) };

            // Act

            // Assert
            Assert.IsTrue(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void OverlapHorizontaalStartpuntIetsNaarRechtsTest()
        {

            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(2, 1) };

            // Act

            // Assert
            Assert.IsFalse(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void OverlapHorizontaalStartpuntIetsNaarLinksTest()
        {

            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(5, 1) };
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(4, 1) };

            // Act

            // Assert
            Assert.IsFalse(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void AangrenzendeOverlapHorizontaalTest()
        {
            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };

            // Horizontaal geen overlap, tegen elkaar aan. lengte van ABCD is 4, dus begint op plek 5.
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(5, 1) };

            // Act

            // Assert
            Assert.IsFalse(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void GeenOverlapHorizontaalTest()
        {
            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };

            // Horizontaal geen overlap, een blokje ertussen. lengte van ABCD is 4, dus begint op plek 6.
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(6, 1) };

            // Act

            // Assert
            Assert.IsTrue(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void OverlapHorizontaalOutOfRangeTest()
        {
            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(3, 1) };

            var diagramOpgave2 = new DiagramOpgave { Opgave = opgaveLang, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };

            // Act

            // Assert
            Assert.IsFalse(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void OverlapHorizontaalOutOfRangeAndersomTest()
        {
            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgaveLang, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };

            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(3, 1) };

            // Act

            // Assert
            Assert.IsFalse(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void GeenOverlapHorizontaalOnderElkaarTest()
        {
            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 1) };
            // Eentje verschoven in horizontale richting
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Horizontaal, StartPunt = new Coordinaat(1, 2) };

            // Act

            // Assert
            Assert.IsTrue(diagramOpgave1.GeenOverlap(diagramOpgave2), "Opgaven hebben geen overlap");
        }

        [TestMethod()]
        public void GeenOverlapVerticaalNaastElkaarTest()
        {
            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 1) };
            // Eentje verschoven in horizontale richting
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Verticaal, StartPunt = new Coordinaat(2, 1) };

            // Act

            // Assert
            Assert.IsTrue(diagramOpgave1.GeenOverlap(diagramOpgave2), "Opgaven hebben geen overlap");
        }

        [TestMethod()]
        public void OverlapVerticaalStartpuntIetsNaarBenedenTest()
        {

            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 1) };
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 2) };

            // Act

            // Assert
            Assert.IsFalse(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void OverlapVerticaalStartpuntIetsNaarBovenTest()
        {

            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 5) };
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 4) };

            // Act

            // Assert
            Assert.IsFalse(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void AangrenzendeOverlapVerticaalTest()
        {
            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 1) };

            // Horizontaal geen overlap, tegen elkaar aan. lengte van ABCD is 4, dus begint op plek 5.
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 5) };

            // Act

            // Assert
            Assert.IsFalse(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }

        [TestMethod()]
        public void GeenOverlapVerticaalTest()
        {
            // Assign
            var diagramOpgave1 = new DiagramOpgave { Opgave = opgave1, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 1) };

            // Horizontaal geen overlap, een blokje ertussen. lengte van ABCD is 4, dus begint op plek 6.
            var diagramOpgave2 = new DiagramOpgave { Opgave = opgave2, Richting = Richting.Verticaal, StartPunt = new Coordinaat(1, 6) };

            // Act

            // Assert
            Assert.IsTrue(diagramOpgave1.GeenOverlap(diagramOpgave2));
        }
    }
}