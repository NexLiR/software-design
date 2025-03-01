using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.HealthInfo.Vaccines;

namespace ZooLib.HealthInfo
{
    public interface IHealthRecord
    {
        string SubjectId { get; }
        string SubjectType { get; }
        DateTime LastCheckup { get; }
        List<IVaccine> Vaccines { get; }
        List<string> MedicalConditions { get; }
        bool IsHealthy { get; }
        void AddVaccine(IVaccine vaccine);
        void AddMedicalCondition(string condition);
        void Checkup(DateTime date);
    }
}
