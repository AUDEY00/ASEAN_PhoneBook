using System;
using System.Collections.Generic;

class PhoneNumber
{
    private int countryCode;
    private int areaCode;
    private long number;

    public int GetCountryCode()
    {
        return countryCode;
    }

    public void SetCountryCode(int code)
    {
        countryCode = code;
    }

    public int GetAreaCode()
    {
        return areaCode;
    }

    public void SetAreaCode(int code)
    {
        areaCode = code;
    }

    public long GetNumber()
    {
        return number;
    }

    public void SetNumber(long num)
    {
        number = num;
    }

    public override string ToString()
    {
        return $"+{GetCountryCode()} ({GetAreaCode()}) {GetNumber()}";
    }
}

class Student
{
    private string studentNumber;
    private string surname;
    private string firstName;
    private string occupation;
    private char gender;
    private PhoneNumber contactNumber;

    public string GetStudentNumber()
    {
        return studentNumber;
    }

    public void SetStudentNumber(string number)
    {
        studentNumber = number;
    }

    public string GetSurname()
    {
        return surname;
    }

    public void SetSurname(string name)
    {
        surname = name;
    }

    public string GetFirstName()
    {
        return firstName;
    }

    public void SetFirstName(string name)
    {
        firstName = name;
    }

    public string GetOccupation()
    {
        return occupation;
    }

    public void SetOccupation(string job)
    {
        occupation = job;
    }

    public char GetGender()
    {
        return gender;
    }

    public void SetGender(char gen)
    {
        gender = gen;
    }

    public PhoneNumber GetContactNumber()
    {
        return contactNumber;
    }

    public void SetContactNumber(PhoneNumber number)
    {
        contactNumber = number;
    }

    public override string ToString()
    {
        return $"{GetStudentNumber()} - {GetFirstName()} {GetSurname()} ({GetOccupation()}) - Gender: {GetGender()} - Contact: {GetContactNumber()}";
    }
}

class ASEANPhonebook
{
    private List<Student> students = new List<Student>();

    public void AddStudent()
    {
        Student student = new Student();

        Console.Write("Enter student number: ");
        student.SetStudentNumber(Console.ReadLine());

        Console.Write("Enter surname: ");
        student.SetSurname(Console.ReadLine());

        Console.Write("Enter first name: ");
        student.SetFirstName(Console.ReadLine());

        Console.Write("Enter occupation: ");
        student.SetOccupation(Console.ReadLine());

        Console.Write("Enter gender (M for male, F for female): ");
        student.SetGender(char.ToUpper(Console.ReadLine()[0]));

        PhoneNumber phoneNumber = new PhoneNumber();
        Console.Write("Enter country code: ");
        phoneNumber.SetCountryCode(int.Parse(Console.ReadLine()));

        Console.Write("Enter area code: ");
        phoneNumber.SetAreaCode(int.Parse(Console.ReadLine()));

        Console.Write("Enter number: ");
        phoneNumber.SetNumber(long.Parse(Console.ReadLine()));

        student.SetContactNumber(phoneNumber);

        students.Add(student);

        Console.Write("Do you want to enter another entry [Y/N]? ");
        if (char.ToUpper(Console.ReadLine()[0]) != 'Y')
            return;
    }

    public void EditEntry()
    { 
        Console.WriteLine("Editing entry in ASEAN phonebook");
    }

    public void SearchByCountry()
    {
        Console.WriteLine("Searching ASEAN phonebook by country");
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\nMAIN MENU");
            Console.WriteLine("[1] Store to ASEAN phonebook");
            Console.WriteLine("[2] Edit entry in ASEAN phonebook");
            Console.WriteLine("[3] Search ASEAN phonebook by country");
            Console.WriteLine("[4] Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    EditEntry();
                    break;
                case "3":
                    SearchByCountry();
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}

class Program
{
    static void Main()
    {
        ASEANPhonebook phonebook = new ASEANPhonebook();
        phonebook.Run();
    }
}



