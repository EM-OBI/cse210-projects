public class AppointmentManager
{
    private List<Patient> _patients;
    private List<Doctor> _doctors;

    public AppointmentManager()
    {

    }
    public void Start()
    {
        int userChoice = 0;
        {
            while (true)
            {
                Console.WriteLine("What action do you want to perform");
                Console.WriteLine("1. Create new Patient \n\t2. See all patients \n\t3. See available doctors \n\t4. Book appointment \n\t5. Quit");
                userChoice = int.Parse(Console.ReadLine());
                if (userChoice == 5)
                {
                    break;
                }
                else if (userChoice == 1)
                {
                    CreatePatient();
                }
                else if (userChoice == 2)
                {
                    SeePatients();
                }
                else if (userChoice == 3)
                {

                }
                else if (userChoice == 4)
                {
                    BookAppointment();
                }
            }
        }
    }
    public void CreateDoctor()
    {

    }
    public void CreatePatient()
    {

    }
    public void SeePatients()
    {

    }
    public void SeeAvailableDoctors()
    {

    }
    public void BookAppointment()
    {

    }
}