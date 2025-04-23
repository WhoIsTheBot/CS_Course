using System;

public class Person
{
    private string _firstName;
    private string _lastName;
    private DateTime _birthDate;

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        _firstName = firstName;
        _lastName = lastName;
        _birthDate = birthDate;
    }

    public Person() : this("John", "Doe", new DateTime(2000, 1, 1)) {}

    public string FirstName
    {
        get => _firstName;
        init => _firstName = value;  
    }

    public string LastName
    {
        get => _lastName;
        init => _lastName = value;  
    }

    public DateTime BirthDate
    {
        get => _birthDate;
        init => _birthDate = value; 
    }

    public int BirthYear
    {
        get => _birthDate.Year;
        set => _birthDate = new DateTime(value, _birthDate.Month, _birthDate.Day);
    }

    public override string ToString()
    {
        return $"{_firstName} {_lastName}, Born: {_birthDate.ToShortDateString()}";
    }

    public string ToShortString()
    {
        return $"{_firstName} {_lastName}";
    }
}
