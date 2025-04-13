using System;

public class Person
{
    private string _firstName;
    private string _lastName;
    private DateTime _birthDate;

    public Person(string FirstName, string LastName, DateTime BirthDate)
    {
        this._firstName = FirstName;
        this._lastName = LastName;
        this._birthDate = BirthDate;
    }

    public Person() : this("John", "Doe", new DateTime(2000, 1, 1)){}

    // Властивість для доступу до поля з іменем
    public string FirstName
    {
        get => _firstName;
        init => _firstName = value;
    }

    // Властивість для доступу до поля з прізвищем
    public string LastName
    {
        get => _lastName;
        init => _lastName = value;
    }

    // Властивість для доступу до поля з датою народження
    public DateTime BirthDate
    {
        get => _birthDate;
        init => _birthDate = value;
    }

    // Властивість для отримання та зміни року народження
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