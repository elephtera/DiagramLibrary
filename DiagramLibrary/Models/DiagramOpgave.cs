using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramLibrary.Models
{
    public class DiagramOpgave
    {
        public Coordinaat StartPunt { get; set; } = new Coordinaat();

        public Richting Richting { get; set; }

        public Opgave? Opgave { get; set; }

        public int Lengte => (Opgave == null || Opgave.Lengte == 0) ? 1 : Opgave.Lengte;

        public bool GeenOverlap(DiagramOpgave diagramOpgave)
        {
            if (diagramOpgave?.Opgave == null || Opgave == null)
            {
                return true;
            }

            if (diagramOpgave.Richting != this.Richting)
            {
                return true;
            }

            bool isXAs = Richting == Richting.Horizontaal;

            if (isXAs ? this.StartPunt.Y != diagramOpgave.StartPunt.Y : this.StartPunt.X != diagramOpgave.StartPunt.X)
            {
                return true;
            }

            var begin = isXAs ? this.StartPunt.X : this.StartPunt.Y;
            var opgaveBegin = isXAs ? diagramOpgave.StartPunt.X : diagramOpgave.StartPunt.Y;

            var rangeBegin = begin - 1;
            var rangeEind = begin + Lengte;

            var opgaveRangeBegin = opgaveBegin;
            var opgaveRangeEind = opgaveBegin + diagramOpgave.Lengte - 1;

            if ((rangeBegin <= opgaveRangeBegin && opgaveRangeBegin <= rangeEind) ||
                (rangeBegin <= opgaveRangeEind && opgaveRangeEind <= rangeEind) ||
                (opgaveRangeBegin <= rangeBegin && rangeEind <= opgaveRangeEind))
            {
                // Als het begin of eindpunt van de diagramOpgave tussen de begin en eindpunten van this ligt, dan is er dus een overlap.
                return false;
            }

            return true;
        }
    }
}
