public class ConsPatient : Patient
{
    private bool _isNecrotic;

    public ConsPatient(string fName, string lName, string id, string gender, int age) : base(fName, lName, id, gender, age)
    {
        _isNecrotic = false;
    }

    public void SetIsNecrotic (bool tOrF)
    {
        _isNecrotic = tOrF;
    }
    public override void BookAppointmentDate(DateTime appointmentDate)
    {
        _appointmentDate = appointmentDate;
    }
    public override string GetStringRepresentation()
    {
        return "";
    }

}