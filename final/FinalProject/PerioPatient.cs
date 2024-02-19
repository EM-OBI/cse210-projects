public class PerioPatient : Patient
{
    private double _ohiScore;
    private string _ohiStatus;

    public PerioPatient(string fName, string lName, string id, string gender, int age, double ohiScore) : base(fName, lName, id, gender, age)
    {
        if (ohiScore <= 1.2)
        {
            _ohiStatus = "Good";
        }
        else if (ohiScore > 1.2 && ohiScore <= 3)
        {
            _ohiStatus = "Fair";
        }
        else if (ohiScore > 3)
        {
            _ohiStatus = "Poor";
        }
        
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