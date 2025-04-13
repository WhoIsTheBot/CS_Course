using System;

public class Person : IDateAndCopy
{
    protected string _firstName;
    protected string _lastName;
    protected DateTime _birthDate;

    public Person(string FirstName, string LastName, DateTime BirthDate)
    {
        _firstName = FirstName;
        _lastName = LastName;
        _birthDate = BirthDate;
        Date = DateTime.Now;
    }

    public Person() : this("John", "Doe", new DateTime(2000, 1, 1)){}

    public string FirstName => _firstName;
    public string LastName => _lastName;
    public DateTime BirthDate => _birthDate;
    public DateTime Date { get; init; }

    public override bool Equals(object? obj)
    {
        if (obj is Person other)
            return _firstName == other._firstName &&
                   _lastName == other._lastName &&
                   _birthDate == other._birthDate;
        return false;
    }

    public static bool operator ==(Person a, Person b) => a.Equals(b);
    public static bool operator !=(Person a, Person b) => !a.Equals(b);

    public override int GetHashCode() =>
        HashCode.Combine(_firstName, _lastName, _birthDate);

    public virtual object DeepCopy() =>
        new Person(_firstName, _lastName, _birthDate);

    public override string ToString()
    {
        return $"{_firstName} {_lastName}, Born: {_birthDate.ToShortDateString()}";
    }

    public virtual  string ToShortString()
    {
        return $"{_firstName} {_lastName}";
    }
}