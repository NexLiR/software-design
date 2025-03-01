using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.HealthInfo.Vaccines
{
    public interface IVaccine
    {
        string Name { get; }
        string Purpose { get; }
        DateTime AdministrationDate { get; }
        DateTime ExpiryDate { get; }
        bool IsValid { get; }
        List<string> TargetSubjects { get; }
        bool IsApplicableTo(string subjectType);
    }
}
