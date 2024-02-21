public class OrthoPatient : Patient
{
    private string _malocclusion;
    private int _anglesClass;

    public OrthoPatient(string fName, string lName, string id, string gender, int age, string type) : base(fName, lName, id, gender, age, type)
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
        return  $"{base.GetName()}||{base.GetGender()}||{base.GetAge()}||{base.GetId()}||{_malocclusion}||{_anglesClass}:{base.GetType()}";
    }

}