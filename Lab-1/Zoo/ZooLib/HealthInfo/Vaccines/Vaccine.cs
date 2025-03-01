using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooLib.HealthInfo.Vaccines
{
    public class Vaccine : IVaccine
    {
        public string Name { get; private set; }
        public string Purpose { get; private set; }
        public DateTime AdministrationDate { get; private set; }
        public DateTime ExpiryDate { get; private set; }
        public List<string> TargetSubjects { get; private set; }

        public bool IsValid => DateTime.Now < ExpiryDate;

        public Vaccine(string name, string purpose, DateTime administrationDate, int validityMonths, List<string> targetSubjects)
        {
            Name = name;
            Purpose = purpose;
            AdministrationDate = administrationDate;
            ExpiryDate = administrationDate.AddMonths(validityMonths);
            TargetSubjects = targetSubjects;
        }

        public bool IsApplicableTo(string subjectType)
        {
            return TargetSubjects.Contains(subjectType);
        }
    }
}
