public class Doctor
{
    private string _firstName;
    private string _lastName;
    private string _specialty;
    private bool _isFree;
    private List<string> _clinicDays;

    public Doctor(string firstName, string lastName, string specialty)
    {
        _firstName = firstName;
        _lastName = lastName;
        _specialty = specialty;
        _isFree = true;
        _clinicDays = new List<string>(); 
    }

    public void AddClinicDay(string day)
    {
        _clinicDays.Add(day);
    }
    public string GetSpecialty()
    {
        return _specialty;
    }
    public bool GetAvailabilityStatus()
    {
        return _isFree;
    }
    public void SetAvailabilityStatus(bool tOrF)
    {
        _isFree = tOrF;
    }
    public string GetDetailsString()
    {
        return $"Dr. {_lastName}, {_firstName} - {_specialty}";
    }
    public string GetStringRepresentation()
    {
        return "";
    }
}