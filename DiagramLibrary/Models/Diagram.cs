using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramLibrary.Models
{
    public class Diagram
    {
        private readonly Collection<DiagramOpgave> diagramOpgaves = new();

        public string Naam { get; set; }

        public Coordinaat Size { get; set; }

        public IReadOnlyCollection<DiagramOpgave> Opgaves => new ReadOnlyCollection<DiagramOpgave>(diagramOpgaves);

        public bool AddOpgave(DiagramOpgave opgave)
        {
            bool geldigeOpgave = true;

            //if(diagramOpgaves.Any(dr => dr.StartPunt == opgave.StartPunt))

            diagramOpgaves.Add(opgave);
            
            return geldigeOpgave;
        }
    }
}
