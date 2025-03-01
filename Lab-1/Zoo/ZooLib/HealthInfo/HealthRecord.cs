using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooLib.HealthInfo.Vaccines;

namespace ZooLib.HealthInfo
{
    public class HealthRecord : IHealthRecord
    {
        public string SubjectId { get; private set; }
        public string SubjectType { get; private set; }
        public DateTime LastCheckup { get; private set; }
        public List<IVaccine> Vaccines { get; private set; } = new List<IVaccine>();
        public List<string> MedicalConditions { get; private set; } = new List<string>();

        public bool IsHealthy => MedicalConditions.Count == 0 && LastCheckup.AddMonths(6) > DateTime.Now;

        public HealthRecord(string subjectId, string subjectType)
        {
            SubjectId = subjectId;
            SubjectType = subjectType;
            LastCheckup = DateTime.Now;
        }

        public void AddVaccine(IVaccine vaccine)
        {
            if (vaccine.IsApplicableTo(SubjectType))
            {
                Vaccines.Add(vaccine);
                Console.WriteLine($"Vaccine {vaccine.Name} administered to {SubjectId}");
            }
            else
            {
                throw new InvalidOperationException($"Vaccine {vaccine.Name} is not applicable to {SubjectType}");
            }
        }

        public void AddMedicalCondition(string condition)
        {
            MedicalConditions.Add(condition);
            Console.WriteLine($"Medical condition {condition} recorded for {SubjectId}");
        }

        public void Checkup(DateTime date)
        {
            LastCheckup = date;
        }
    }
}
