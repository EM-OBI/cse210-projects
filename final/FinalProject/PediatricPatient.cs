public class PediatricPatient : Patient
{
    private bool _growthComplete;
    private string _stageDentition;

    public PediatricPatient(string fName, string lName, string id, string gender, int age, string stageDentition, string type) : base(fName, lName, id, gender, age, type)
    {
        _stageDentition = stageDentition;
        if (gender == "F" && age > 17)
        {
            _growthComplete = true;
        }
        else if (gender == "M" && age > 19)
        {
            _growthComplete = true;
        }
        else 
        {
            _growthComplete = false;
        }
    }

    public override void BookAppointmentDate(DateTime appointmentDate)
    {
        _appointmentDate = appointmentDate;
    }
    public override string GetStringRepresentation()
    {
        return  $"{base.GetName()}||{base.GetGender()}||{base.GetAge()}||{base.GetId()}||{_growthComplete}||{_stageDentition}:{base.GetType()}";
    }

}