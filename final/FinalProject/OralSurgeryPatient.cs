public class OralSurgeryPatient : Patient
{
    private bool _surgicalExo;
    private bool _retainedRoot;

    public OralSurgeryPatient(string fName, string lName, string id, string gender, int age, string type) : base(fName, lName, id, gender, age, type)
    {
        _surgicalExo = false;
        _retainedRoot = false;
    }

    public void SetSurgicalExo (bool tOrF)
    {
        _surgicalExo = tOrF;
    }
    public void SetRetainedRoot (bool tOrF)
    {
        _retainedRoot = tOrF;
    }
    public override void BookAppointmentDate(DateTime appointmentDate)
    {
        _appointmentDate = appointmentDate;
    }
    public override string GetStringRepresentation()
    {
        return  $"{base.GetName()}||{base.GetGender()}||{base.GetAge()}||{base.GetId()}||{_surgicalExo}||{_retainedRoot}||{_appointmentDate}={base.GetType()}";
    }

}