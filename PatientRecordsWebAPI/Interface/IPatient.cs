using PatientRecordsWebAPI.Model;

namespace PatientRecordsWebAPI.Interface
{
    public interface IPatient
    {
        List<Patient> RetrieveAllPatients();
        object RetrievePatient(int patientId);
        object AddPatient(Patient patientInfo);
        object UpdatePatient(int patientId, Patient patientInfo);
        object DeletePatient(int patientId);
    }
}
