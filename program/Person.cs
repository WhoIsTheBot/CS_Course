using System;
using System.Collections.Generic;

public class Person : IComparable, IComparer<Person>
{
    protected string _firstName;
    protected string _lastName;
    protected DateTime _birthDate;

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        _firstName = firstName;
        _lastName = lastName;
        _birthDate = birthDate;
    }

    public Person() : this("John", "Doe", new DateTime(2000, 1, 1)) { }

    public string FirstName => _firstName;
    public string LastName => _lastName;
    public DateTime BirthDate => _birthDate;

    public int CompareTo(object? obj)
    {
        if (obj is Person other)
            return string.Compare(this._lastName, other._lastName, StringComparison.Ordinal);
        throw new ArgumentException("Object is not a Person");
    }

    public int Compare(Person? x, Person? y)
    {
        if (x == null || y == null) throw new ArgumentException("Null value");
        return DateTime.Compare(x._birthDate, y._birthDate);
    }

    public override string ToString() =>
        $"{_firstName} {_lastName}, {BirthDate.ToShortDateString()}";
}
