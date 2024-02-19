public class OrthoPatient : Patient
{
    private string _malocclusion;
    private int _anglesClass;

    public OrthoPatient(string fName, string lName, string id, string gender, int age) : base(fName, lName, id, gender, age)
    {
        _malocclusion = "";
        _anglesClass = 0;
    }
    public void SetMalocclusion(string malocclusion)
    {
        _malocclusion = malocclusion;
    }
    public void SetAnglesClass(int anglesClass)
    {
        _anglesClass = anglesClass;
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