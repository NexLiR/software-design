using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.Enclosures
{
    public class TerrestrialEnclosure : Enclosure
    {
        public double LandArea { get; private set; }
        public string TerrainType { get; private set; }

        public TerrestrialEnclosure(string name, int capacity, List<string> compatibleSpecies, double landArea, string terrainType)
            : base(name, "Terrestrial", capacity, compatibleSpecies)
        {
            LandArea = landArea;
            TerrainType = terrainType;
        }
    }
}
