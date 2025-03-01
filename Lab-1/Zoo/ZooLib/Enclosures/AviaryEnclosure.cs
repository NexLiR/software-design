using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.Enclosures
{
    public class AviaryEnclosure : Enclosure
    {
        public double Height { get; private set; }
        public bool HasRoof { get; private set; }

        public AviaryEnclosure(string name, int capacity, List<string> compatibleSpecies, double height, bool hasRoof)
            : base(name, "Aviary", capacity, compatibleSpecies)
        {
            Height = height;
            HasRoof = hasRoof;
        }
    }
}
