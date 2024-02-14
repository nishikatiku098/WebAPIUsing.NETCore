namespace PatientRecordsWebAPI.Model
{
    public class Patient
    {
        public int PatientId { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public string BloodType { get; set; }
        public string LastVisit { get; set; }

        public Patient(int patientId, int weight, int height, string bloodType, string lastVisit)
        {
            PatientId = patientId;
            Weight = weight;
            Height = height;
            BloodType = bloodType;
            LastVisit = lastVisit;
        }
    }
}
