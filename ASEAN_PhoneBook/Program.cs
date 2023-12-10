using System;
using System.Collections.Generic;


class PhoneNumber
{
    public int CountryCode { get; set; }
    public int AreaCode { get; set; }
    public long Number { get; set; }
    public string CountryName { get; set; }

    public override string ToString()
    {
        return $"+{CountryCode} ({AreaCode}) {Number}";
    }
}

class Student
{
    public string StudentNumber { get; set; }
    public string Surname { get; set; }
    public string FirstName { get; set; }
    public string Occupation { get; set; }
    public char Gender { get; set; }
    public PhoneNumber ContactNumber { get; set; }

    public override string ToString()
    {
        return $"{StudentNumber} - {FirstName} {Surname} ({Occupation}) - Gender: {Gender} - Contact: {ContactNumber}";
    }
}

class ASEANPhonebook
{
    private List<Student> students = new List<Student>();

    public void AddStudent(Student student)
    {
        students.Add(student);
    }

    public void EditStudent(string studentNumber)
    {
        Student student = FindStudentByNumber(studentNumber);

        if (student == null)
        {
            Console.WriteLine("Student not found!");
            return;
        }

        Console.WriteLine($"Here is the existing information about {student.StudentNumber}: {student}");
        int choice;
        do
        {
            Console.WriteLine("Which of the following information do you wish to change?");
            Console.WriteLine("[1] Student number [2] Surname [3] Gender [4] Occupation [5] Country name [6] Area code [7] Phone number [8] None - Go back to main menu");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter new student number: ");
                        student.StudentNumber = Console.ReadLine();
                        break;
                    case 2:
                        Console.Write("Enter new surname: ");
                        student.Surname = Console.ReadLine();
                        break;
                    case 3:
                        Console.Write("Enter new gender (M/F): ");
                        student.Gender = char.ToUpperInvariant(Console.ReadLine()[0]);
                        break;
                    case 4:
                        Console.Write("Enter new occupation: ");
                        student.Occupation = Console.ReadLine();
                        break;
                    case 5:
                        EditCountry(student);
                        break;
                    case 6:
                        Console.Write("Enter new area code: ");
                        student.ContactNumber.AreaCode = int.Parse(Console.ReadLine());
                        break;
                    case 7:
                        Console.Write("Enter new phone number: ");
                        student.ContactNumber.Number = long.Parse(Console.ReadLine());
                        break;
                    case 8:
                        return; // Balik sa menu
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        } while (choice != 8);
    }

    private void EditCountry(Student student)
    {
        Console.WriteLine("Choose Country:");
        Console.WriteLine("[1] Philippines");
        Console.WriteLine("[2] Thailand");
        Console.WriteLine("[3] Singapore");
        Console.WriteLine("[4] Indonesia");
        Console.WriteLine("[5] Malaysia");

        int countryChoice;
        if (int.TryParse(Console.ReadLine(), out countryChoice) && countryChoice >= 1 && countryChoice <= 5)
        {
            string countryName;
            int countryCode;

            switch (countryChoice)
            {
                case 1:
                    countryName = "Philippines";
                    countryCode = 63;
                    break;
                case 2:
                    countryName = "Thailand";
                    countryCode = 66;
                    break;
                case 3:
                    countryName = "Singapore";
                    countryCode = 65;
                    break;
                case 4:
                    countryName = "Indonesia";
                    countryCode = 62;
                    break;
                case 5:
                    countryName = "Malaysia";
                    countryCode = 60;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Defaulting to Philippines.");
                    countryName = "Philippines";
                    countryCode = 63;
                    break;
            }

            Console.WriteLine($"Country code: {countryCode}+");
            student.ContactNumber.CountryName = countryName;
            student.ContactNumber.CountryCode = countryCode;
        }
        else
        {
            Console.WriteLine("Invalid input for country choice. Defaulting to Philippines.");
        }
    }

    public void SearchByCountry()
    {
        Console.WriteLine("Choose a country to search:");
        Console.WriteLine("[0] Stop");
        Console.WriteLine("[1] Philippines");
        Console.WriteLine("[2] Thailand");
        Console.WriteLine("[3] Singapore");
        Console.WriteLine("[4] Indonesia");
        Console.WriteLine("[5] Malaysia");

        List<string> selectedCountries = new List<string>();

        while (true)
        {
            int countryChoice;
            if (int.TryParse(Console.ReadLine(), out countryChoice))
            {
                if (countryChoice == 0)
                {
                    break;
                }
                else if (countryChoice >= 1 && countryChoice <= 5)
                {
                    string countryName;
                    switch (countryChoice)
                    {
                        case 1:
                            countryName = "Philippines";
                            break;
                        case 2:
                            countryName = "Thailand";
                            break;
                        case 3:
                            countryName = "Singapore";
                            break;
                        case 4:
                            countryName = "Indonesia";
                            break;
                        case 5:
                            countryName = "Malaysia";
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Defaulting to Philippines.");
                            countryName = "Philippines";
                            break;
                    }
                    selectedCountries.Add(countryName);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }

        if (selectedCountries.Count == 0)
        {
            Console.WriteLine("No countries selected. Exiting search.");
            return;
        }

        List<Student> selectedStudents = new List<Student>();

        foreach (var student in students)
        {
            if (selectedCountries.Contains(student.ContactNumber.CountryName, StringComparer.OrdinalIgnoreCase))
            {
                selectedStudents.Add(student);
            }
        }

        selectedStudents.Sort((s1, s2) => s1.Surname.CompareTo(s2.Surname));

        foreach (var student in selectedStudents)
        {
            Console.WriteLine(student);
        }
    }

    private Student FindStudentByNumber(string studentNumber)
    {
        foreach (var student in students)
        {
            if (student.StudentNumber == studentNumber)
            {
                return student;
            }
        }
        return null;
    }
}

class Program
{
    static void Main(string[] args)
    {
        ASEANPhonebook phonebook = new ASEANPhonebook();

        int choice;
        do
        {
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("[1] Store to ASEAN phonebook");
            Console.WriteLine("[2] Edit entry in ASEAN phonebook");
            Console.WriteLine("[3] Search ASEAN phonebook by country");
            Console.WriteLine("[4] Exit");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        AddStudent(phonebook);
                        break;
                    case 2:
                        EditStudent(phonebook);
                        break;
                    case 3:
                        phonebook.SearchByCountry();
                        break;
                    case 4:
                        Console.WriteLine("Exiting the program.");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (choice != 4);
    }

    static void AddStudent(ASEANPhonebook phonebook)
    {
        do
        {
            Console.Write("Enter student number: ");
            string studentNumber = Console.ReadLine();

            Console.Write("Enter surname: ");
            string surname = Console.ReadLine();

            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();

            Console.Write("Enter occupation: ");
            string occupation = Console.ReadLine();

            Console.Write("Enter gender (M for male, F for female): ");
            char gender = char.ToUpperInvariant(Console.ReadLine()[0]);

            Console.WriteLine("Choose Country:");
            Console.WriteLine("[1] Philippines");
            Console.WriteLine("[2] Thailand");
            Console.WriteLine("[3] Singapore");
            Console.WriteLine("[4] Indonesia");
            Console.WriteLine("[5] Malaysia");

            int countryChoice;
            if (int.TryParse(Console.ReadLine(), out countryChoice) && countryChoice >= 1 && countryChoice <= 5)
            {
                string countryName;
                int countryCode;

                switch (countryChoice)
                {
                    case 1:
                        countryName = "Philippines";
                        countryCode = 63;
                        break;
                    case 2:
                        countryName = "Thailand";
                        countryCode = 66;
                        break;
                    case 3:
                        countryName = "Singapore";
                        countryCode = 65;
                        break;
                    case 4:
                        countryName = "Indonesia";
                        countryCode = 62;
                        break;
                    case 5:
                        countryName = "Malaysia";
                        countryCode = 60;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Defaulting to Philippines.");
                        countryName = "Philippines";
                        countryCode = 63;
                        break;
                }

                Console.WriteLine($"Country code: {countryCode}+");

                Console.Write("Enter area code: ");
                int areaCode = int.Parse(Console.ReadLine());

                Console.Write("Enter number: ");
                long phoneNumber = long.Parse(Console.ReadLine());

                var student = new Student
                {
                    StudentNumber = studentNumber,
                    Surname = surname,
                    FirstName = firstName,
                    Occupation = occupation,
                    Gender = gender,
                    ContactNumber = new PhoneNumber
                    {
                        CountryName = countryName,
                        CountryCode = countryCode,
                        AreaCode = areaCode,
                        Number = phoneNumber
                    }
                };

                phonebook.AddStudent(student);
            }
            else
            {
                Console.WriteLine("Invalid input for country choice. Defaulting to Philippines.");
            }

            Console.Write("Do you want to enter another entry [Y/N]? ");
        } while (Console.ReadLine().ToUpper() == "Y");
    }

    static void EditStudent(ASEANPhonebook phonebook)
    {
        Console.Write("Enter student number to edit: ");
        string studentNumber = Console.ReadLine();
        phonebook.EditStudent(studentNumber);
    }
}
