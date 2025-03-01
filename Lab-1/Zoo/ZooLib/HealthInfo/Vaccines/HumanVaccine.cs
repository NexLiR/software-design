using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.HealthInfo.Vaccines
{
    public class HumanVaccine : Vaccine
    {
        public HumanVaccine(string name, string purpose, DateTime administrationDate, int validityMonths)
            : base(name, purpose, administrationDate, validityMonths, new List<string> { "Employee" })
        {

        }
    }
}
