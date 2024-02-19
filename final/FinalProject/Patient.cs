public abstract class Patient
{
    private string _firstName;
    private string _lastName;
    private string _patientId;
    private string _gender;
    private int _age;
    private Doctor _doctor;
    protected DateTime _appointmentDate;

    public Patient(string fName, string lName, string id, string gender, int age)
    {
        _firstName = fName;
        _lastName = lName;
        _patientId = id;
        _gender = gender;
        _age = age;
        _appointmentDate = new DateTime();
    }
    public void SetDoctor (Doctor doctor)
    {
        _doctor = doctor;
    }
    public abstract void BookAppointmentDate(DateTime appointmentDate);

    public string GetDetailsString()
    {
        return $"{_lastName}, {_firstName} | {_gender}/{_age} - {_patientId}";
    }
    public abstract string GetStringRepresentation();
} 