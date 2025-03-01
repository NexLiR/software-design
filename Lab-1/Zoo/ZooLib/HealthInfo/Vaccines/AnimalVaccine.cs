using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.HealthInfo.Vaccines
{
    public class AnimalVaccine : Vaccine
    {
        public List<string> TargetSpecies { get; private set; }

        public AnimalVaccine(string name, string purpose, DateTime administrationDate, int validityMonths, List<string> targetSpecies)
            : base(name, purpose, administrationDate, validityMonths, new List<string> { "Animal" })
        {
            TargetSpecies = targetSpecies;
        }
    }
}
