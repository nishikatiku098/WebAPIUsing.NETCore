using PatientRecordsWebAPI.Interface;
using PatientRecordsWebAPI.Model;

namespace PatientRecordsWebAPI.Repository
{
    public class PatientRepository : IPatient
    {
        static List<Patient> patientRecordsList = new List<Patient>
        {
           new Patient(1, 70, 175, "O+", "2022-02-14"),
           new Patient(2, 65, 170, "A-", "2022-02-10"),
           new Patient(3, 75, 180, "B+", "2022-02-12"),
           new Patient(4, 80, 185, "AB+", "2022-02-08"),
        };
        public object AddPatient(Patient patientInfo)
        {
            //get the Patient by patientId
            Patient existingPatient = patientRecordsList.Where(patient => patient.PatientId == patientInfo.PatientId).FirstOrDefault();

            //if the patient already exists, then return the  error message
            if (existingPatient!=null)
            {
                throw new Exception("Cannot add Patient since Patient already exists");
            }

            //if the patient doesn't exist, create the Patient
            else
            {
                int patientCount = patientRecordsList.Count;

                //add the Patient
                patientRecordsList.Add(patientInfo);

                //if the count increases by one, return the Patient
                if ((patientCount + 1) > patientCount)
                {
                    return patientInfo;
                }

                //if the patient wasn't added, then return the  error message
                throw new Exception("Unable to add the Patient due to some error");
            }
        }

        public object DeletePatient(int patientId)
        {
            //get the Patient by patientId
            Patient patientToRemove = patientRecordsList.Where(patient => patient.PatientId == patientId).FirstOrDefault();

            //if the patient exists, delete the Patient
            if (patientToRemove != null)
            {
                patientRecordsList.Remove(patientToRemove);
                return "Patient removed successfully";
            }
            //if the patient doesn't exist, then return the  error message
            throw new Exception("Unable to delete since Patient does not exist");
        }

        public List<Patient> RetrieveAllPatients()
        {
            return patientRecordsList;
        }

        public object RetrievePatient(int patientId)
        {
            //get the Patient by patientId
            Patient patientToRetrieve = patientRecordsList.Where(patient => patient.PatientId == patientId).FirstOrDefault();

            //if the patient exists, return the Patient
            if (patientToRetrieve != null)
            {
                return patientToRetrieve;
            }
            //if the patient doesn't exist, then return the  error message
            throw new Exception("Unable to retrieve since Patient does not exist");
        }

        public object UpdatePatient(int patientId,Patient patientInfo)
        {
            //get the Patient by patientId
            Patient patientToUpdate = patientRecordsList.Where(patient => patient.PatientId == patientId).FirstOrDefault();

            //if the patient exists, replace all the fields with the given fields
            if (patientToUpdate != null)
            {
                patientToUpdate.Weight = patientInfo.Weight;
                patientToUpdate.Height = patientInfo.Height;
                patientToUpdate.BloodType = patientInfo.BloodType;
                patientToUpdate.LastVisit = patientInfo.LastVisit;
                return patientToUpdate;
            }
            //if the patient doesn't exist, then return the  error message
            throw new Exception("Unable to update since Patient does not exist");
        }
    }
}
