public class Doctor
{
    private string _firstName;
    private string _lastName;
    private string _specialty;
    private bool _isFree;
    private int _id;

    public Doctor(string firstName, string lastName, string specialty, int id)
    {
        _firstName = firstName;
        _lastName = lastName;
        _specialty = specialty;
        _id = id;
        _isFree = false;
       
    }
    public Doctor(string firstName, string lastName, string specialty, int id, bool isFree)
    {
        _firstName = firstName;
        _lastName = lastName;
        _specialty = specialty;
        _id = id;
        _isFree = isFree;

    }
    public string GetName()
    {
        return $"Dr. {_lastName}, {_firstName}";
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
        return $"{_specialty}:{_lastName}||{_firstName}||{_isFree}||{_id} ";
    }
}