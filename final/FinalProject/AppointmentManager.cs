public class AppointmentManager
{
    private List<Patient> _patients;
    private List<Doctor> _doctors;
    private string _password = "77*7times";

    public AppointmentManager()
    {
        _patients = new List<Patient>();
        _doctors = new List<Doctor>();
        Start();
    }
    public void Start()
    {
        Console.Write("Are you an admin? yes/no: ");
        string admin = Console.ReadLine().ToLower();
        if (admin == "yes")
        {
            Console.Write("Enter your admin password: ");
            string password = Console.ReadLine();
            if (password == _password)
            {
                while(true)
                {
                    Console.WriteLine("\t1. Create new Patient \n\t2. Create new Doctor \n\t3. See all patients \n\t4. See alldoctors \n\t5. See available doctors \n\t6. Make doctor available \n\t7. Book appointment \n\t8. Quit");
                    int adminChoice = int.Parse(Console.ReadLine());
                    if (adminChoice == 8)
                    {
                        break;
                    }
                    else if (adminChoice == 1)
                    {
                        CreatePatient();
                    }
                    else if (adminChoice == 2)
                    {
                        CreateDoctor();
                    }
                    else if (adminChoice == 3)
                    {
                        SeeAllPatients();
                    }
                    else if (adminChoice == 4)
                    {
                        SeeAllDoctors();
                    }
                    else if (adminChoice == 5)
                    {
                        SeeAvailableDoctors();
                    }
                    else if (adminChoice == 6)
                    {
                        MakeDoctorAvailable();
                    }
                    else if (adminChoice == 7)
                    {
                        BookAppointment();
                    }
                }  
            }
            else
            {
                Console.WriteLine("Wrong admin password! Start program and try again!");
            }
        }
        else if (admin == "no")
        {
            Console.WriteLine("Only admins can access. Thank you!");
        } 
    }
    public void CreatePatient()
    {
        // _patients = new List<Patient>();
        Random randomId = new Random();
        int id = randomId.Next(0, 100000000);
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        Console.Write("Gender(M/F): ");
        string gender = Console.ReadLine();
        string patientId = id.ToString();
        Console.Write("Age: ");
        int age = int.Parse(Console.ReadLine());
        Console.WriteLine("Patient type: \n\t1. Conservative Dentistry \n\t2. Orthodontics \n\t3. Oral and Maxillofacial Surgery \n\t4. Pediatric Dentistry \n\t5. Periodontics");
        string type = Console.ReadLine();
        _patients = new List<Patient>();
        if (type == "1")
        {
            type = "Conservative Dentistry";
            ConsPatient consPatient = new ConsPatient(firstName, lastName, patientId, gender, age, type);
            // BookAppointment(consPatient);
            _patients.Add(consPatient);
        }
        else if (type == "2")
        {
            type = "Orthodontics";
            OrthoPatient orthoPatient = new OrthoPatient(firstName, lastName, patientId, gender, age, type);
            // BookAppointment(orthoPatient);
            _patients.Add(orthoPatient);
        }
        else if (type == "3")
        {
            type = "Oral and Maxillofacial Surgery";
            OralSurgeryPatient oralSurgeryPatient = new OralSurgeryPatient(firstName, lastName, patientId, gender, age, type);
            // BookAppointment(oralSurgeryPatient);
            _patients.Add(oralSurgeryPatient);
        }
        else if (type == "4")
        {
            type = "Pedodontics";
            Console.WriteLine("Stage dentition: \n\t1. Primary \n\t2. Mixed \n\t3. Permanent");
            int stageChoice = int.Parse(Console.ReadLine());
            string stage = "";
            if (stageChoice == 1)
            {
                stage = "primary";
            }
            else if (stageChoice == 2)
            {
                stage = "mixed";
            }
            else if (stageChoice == 3)
            {
                stage = "permanent";
            }
            PediatricPatient pediatricPatient = new PediatricPatient(firstName, lastName, patientId, gender, age, stage, type);
            // BookAppointment(pediatricPatient);
            _patients.Add(pediatricPatient);
        }
        else if (type == "5")
        {
            type = "Periodontics";
            Console.Write("Enter OHI score: ");
            double ohiScore = Double.Parse(Console.ReadLine());
            PerioPatient perioPatient = new PerioPatient(firstName, lastName, patientId, gender, age, ohiScore, type);
            // BookAppointment(perioPatient);
            _patients.Add(perioPatient);
        }
        SavePatient();
    }
    public void CreateDoctor()
    {
        Random randomId = new Random();
        int id = randomId.Next(0, 1000);
        Console.Write("First Name: ");
        string firstName = Console.ReadLine();
        Console.Write("Last Name: ");
        string lastName = Console.ReadLine();
        Console.WriteLine("Specialty: \n\t1. Conservative Dentistry \n\t2. Orthodontics \n\t3. Oral and Maxillofacial Surgery \n\t4. Pediatric Dentistry \n\t5. Periodontics");

        string specialty = Console.ReadLine();
        if (specialty == "1")
        {
            specialty = "Conservative Dentistry";
        }
        else if (specialty == "2")
        {
            specialty = "Orthodontics";
        }
        else if (specialty == "3")
        {
            specialty = "Oral and Maxillofacial Surgery";
        }
        else if (specialty == "4")
        {
            specialty = "Pedodontics";
        }
        else if (specialty == "5")
        {
            specialty = "Periodontics";
        }
        Doctor doctor = new Doctor(firstName, lastName, specialty, id);
        _doctors.Add(doctor);
        SaveDoctor();
    }
    public void SaveDoctor()
    {
        string fileName = "doctors.txt";
        using (StreamWriter outputFile = new StreamWriter(fileName, true))
        {
            foreach(Doctor d in _doctors)
            {

                {
                    outputFile.WriteLine($"{d.GetStringRepresentation()}");
                }
            }
        }
        
    }
    public void SavePatient()
    {
        string fileName = "patients.txt";
        using (StreamWriter outputFile = new StreamWriter(fileName, true))
        {
            foreach(Patient p in _patients)
            {
                {
                    outputFile.WriteLine($"{p.GetStringRepresentation()}");
                }
            }
        }
    }
    public void SeeAllPatients()
    {
        string fileName = "patients.txt";
        try
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
        
            List<Patient> _patients = new List<Patient>();
            foreach (string line in lines)
            {
                string[] partsLine = line.Split("=");

                string patientType = partsLine[1];
                string patientStuff = partsLine[0];
                string[] patientDetails = patientStuff.Split("||");
                string name = patientDetails[0];
                string[] patientName = name.Split(",");
                string lName = patientName[1];
                string fName = patientName[0];
                string gender = patientDetails[1];
                int age = int.Parse(patientDetails[2]);
                string id = patientDetails[3];
                if (patientType == "Conservative Dentistry")
                {
                    ConsPatient consPatient = new ConsPatient(fName, lName, id, gender, age, patientType);
                    // simpleGoal.SetCompletedStatus(bool.Parse(partsDetails[3]));
        
                    _patients.Add(consPatient);
                }
                else if(patientType == "Orthodontics")
                {
                    OrthoPatient orthoPatient = new OrthoPatient(fName, lName, id, gender, age, patientType);
                    
                    _patients.Add(orthoPatient);
                }
                else if(patientType == "Oral and Maxillofacial Surgery")
                {
                    OralSurgeryPatient oralSurgeryPatient = new OralSurgeryPatient(fName, lName, id, gender, age, patientType);
                    
                    _patients.Add(oralSurgeryPatient);
                }
                else if(patientType == "Pedodontics")
                {
                    string stage = patientDetails[4];
                    PediatricPatient pediatricPatient = new PediatricPatient(fName, lName, id, gender, age, stage, patientType);
                    _patients.Add(pediatricPatient);
                }
                else if(patientType == "Periodontics")
                {
                    double ohi = double.Parse(patientDetails[4]);
                    PerioPatient perioPatient = new PerioPatient(fName, lName, id, gender, age, ohi, patientType);
                    _patients.Add(perioPatient);
                }
            }
            int patientCount = 1;
            foreach (Patient patient in _patients)
            {
                Console.WriteLine($"{patientCount}. {patient.GetDetailsString()}");
                patientCount++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }
    public void SeeAllDoctors()
    {
        string fileName = "doctors.txt";
        try
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
        
            List<Doctor> _doctors = new List<Doctor>();
            foreach (string line in lines)
            {
                string[] partsLine = line.Split(":");

                string doctorType = partsLine[0];
                string doctorStuff = partsLine[1];
                string[] doctorDetails = doctorStuff.Split("||");
                string fName = doctorDetails[1];
                string lName = doctorDetails[0];
                int id = int.Parse(doctorDetails[3]);
                bool isFree = bool.Parse(doctorDetails[2]);
                Doctor doctor = new Doctor(fName, lName, doctorType, id);
                _doctors.Add(doctor);

            }
            int doctorCount = 1;
            foreach (Doctor doctor in _doctors)
            {
                Console.WriteLine($"{doctorCount}. {doctor.GetDetailsString()}");
                doctorCount++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }

    }
    public void MakeDoctorAvailable()
    {
        SeeAllDoctors();
        string fileName = "doctors.txt";
        try
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            List<Doctor> _doctors = new List<Doctor>();
            bool isFree;
            foreach (string line in lines)
            {
                string[] partsLine = line.Split(":");

                string doctorType = partsLine[0];
                string doctorStuff = partsLine[1];
                string[] doctorDetails = doctorStuff.Split("||");
                string fName = doctorDetails[1];
                string lName = doctorDetails[0];
                int id = int.Parse(doctorDetails[3]);
                isFree = bool.Parse(doctorDetails[2]);
                Doctor doctor = new Doctor(fName, lName, doctorType, id, isFree);
                _doctors.Add(doctor);

            }
            Console.Write("Which Doctor would you like to make available: ");
            int doctorNumber = int.Parse(Console.ReadLine());
            if (doctorNumber >= 1 && doctorNumber <= _doctors.Count && !_doctors[doctorNumber - 1].GetAvailabilityStatus())
            {
                _doctors[doctorNumber - 1].SetAvailabilityStatus(true);
            }
            else
            {
                _doctors[doctorNumber - 1].SetAvailabilityStatus(false);
            }
            string file = "doctors.txt";
            using (StreamWriter outputFile = new StreamWriter(file))
            {
                foreach (Doctor doctor in _doctors)
                {
                    outputFile.WriteLine($"{doctor.GetStringRepresentation()}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }
    public void SeeAvailableDoctors()
    {
        string fileName = "doctors.txt";
        try
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
        
            List<Doctor> _doctors = new List<Doctor>();
            bool isFree;
            foreach (string line in lines)
            {
                string[] partsLine = line.Split(":");

                string doctorType = partsLine[0];
                string doctorStuff = partsLine[1];
                string[] doctorDetails = doctorStuff.Split("||");
                string fName = doctorDetails[1];
                string lName = doctorDetails[0];
                int id = int.Parse(doctorDetails[3]);
                isFree = bool.Parse(doctorDetails[2]);
                Doctor doctor = new Doctor(fName, lName, doctorType, id, isFree);
                _doctors.Add(doctor);

            }
            int doctorCount = 1;
            foreach (Doctor doctor in _doctors)
            {
                if (doctor.GetAvailabilityStatus())
                {
                    Console.WriteLine($"{doctorCount}. {doctor.GetDetailsString()}");
                    doctorCount++;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }
    public void BookAppointment()
    {
         
        try
        {
            SeeAllPatients();
            string fileName = "patients.txt";
            string[] lines = System.IO.File.ReadAllLines(fileName);
        
            // List<Patient> _loadPatient = new List<Patient>();
            foreach (string line in lines)
            {
                string[] partsLine = line.Split("=");

                string patientType = partsLine[1];
                string patientStuff = partsLine[0];
                string[] patientDetails = patientStuff.Split("||");
                string name = patientDetails[0];
                string[] patientName = name.Split(",");
                string lName = patientName[1];
                string fName = patientName[0];
                string gender = patientDetails[1];
                int age = int.Parse(patientDetails[2]);
                string id = patientDetails[3];
                if (patientType == "Conservative Dentistry")
                {
                    ConsPatient consPatient = new ConsPatient(fName, lName, id, gender, age, patientType);
                    _patients.Add(consPatient);
                }
                else if(patientType == "Orthodontics")
                {
                    OrthoPatient orthoPatient = new OrthoPatient(fName, lName, id, gender, age, patientType);
                    
                    _patients.Add(orthoPatient);
                }
                else if(patientType == "Oral and Maxillofacial Surgery")
                {
                    OralSurgeryPatient oralSurgeryPatient = new OralSurgeryPatient(fName, lName, id, gender, age, patientType);
                    
                    _patients.Add(oralSurgeryPatient);
                }
                else if(patientType == "Pedodontics")
                {
                    string stage = patientDetails[4];
                    PediatricPatient pediatricPatient = new PediatricPatient(fName, lName, id, gender, age, stage, patientType);
                    _patients.Add(pediatricPatient);
                }
                else if(patientType == "Periodontics")
                {
                    double ohi = double.Parse(patientDetails[4]);
                    PerioPatient perioPatient = new PerioPatient(fName, lName, id, gender, age, ohi, patientType);
                    _patients.Add(perioPatient);
                }
            }
            Console.WriteLine("Patient for appointment: ");
            int patientToBook = int.Parse(Console.ReadLine());
            Console.WriteLine("Appointment date (yyyy-MM-dd HH:mm): ");
            DateTime dateAndTime = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("X");
            Patient selectedPatient = _patients[patientToBook - 1];
            selectedPatient.BookAppointmentDate(dateAndTime);
            SeeAvailableDoctors();


            string Name = "doctors.txt";
            try
            {
                string[] docLines = System.IO.File.ReadAllLines(Name);
                List<Doctor> _doctors = new List<Doctor>();
                bool isFree;
                foreach (string line in docLines)
                {
                    string[] partsLine = line.Split(":");

                    string doctorType = partsLine[0];
                    string doctorStuff = partsLine[1];
                    string[] doctorDetails = doctorStuff.Split("||");
                    string fName = doctorDetails[1];
                    string lName = doctorDetails[0];
                    int id = int.Parse(doctorDetails[3]);
                    isFree = bool.Parse(doctorDetails[2]);
                    Doctor doctor = new Doctor(fName, lName, doctorType, id, isFree);
                    if (doctor.GetAvailabilityStatus())
                    {
                        _doctors.Add(doctor);
                    }

                }
                Console.Write("Which Doctor would you like to book: ");
                int doctorNumber = int.Parse(Console.ReadLine());
                if (doctorNumber >= 1 && doctorNumber <= _doctors.Count)
                {
                    _doctors[doctorNumber - 1].SetAvailabilityStatus(false);
                    Console.WriteLine($"{_doctors[doctorNumber - 1].GetName()} has been booked successfully");
                }
                else
                {
                    _doctors[doctorNumber - 1].SetAvailabilityStatus(true);
                }
                string file = "doctors.txt";
                using (StreamWriter outputFile = new StreamWriter(file))
                {
                    foreach (Doctor doctor in _doctors)
                    {
                        outputFile.WriteLine($"{doctor.GetStringRepresentation()}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occured: {ex.Message}");
            }

            string nameFile = "bookedpatients.txt";
            using (StreamWriter outputFile = new StreamWriter(nameFile, true))
            {
                foreach(Patient p in _patients)
                {
                    {
                        outputFile.WriteLine($"{p.GetStringRepresentation()}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occured: {ex.Message}");
        }
    }
}