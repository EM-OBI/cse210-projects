public abstract class Patient
{
    private string _firstName;
    private string _lastName;
    private string _patientId;
    private string _gender;
    private int _age;
    private string _type;
    private Doctor _doctor;
    protected DateTime _appointmentDate;

    public Patient(string fName, string lName, string id, string gender, int age, string type)
    {
        _firstName = fName;
        _lastName = lName;
        _patientId = id;
        _gender = gender;
        _age = age;
        _type = type;
        _appointmentDate = new DateTime();
    }
    public string GetName()
    {
        return $"{_lastName}, {_firstName}";
    }
    public string GetId()
    {
        return _patientId;
    }
    public string GetGender()
    {
        return _gender;
    }
    
    public int GetAge()
    {
        return _age;
    }
    public string GetType()
    {
        return _type;
    }
    public abstract void BookAppointmentDate(DateTime appointmentDate);

    public string GetDetailsString()
    {
        return $"{_lastName}, {_firstName} | {_gender}/{_age} - {_patientId}";
    }
    public abstract string GetStringRepresentation();
} 