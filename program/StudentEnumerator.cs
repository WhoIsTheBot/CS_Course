using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class StudentEnumerator : IEnumerator<string>
{
    private List<string> _commonSubjects;
    private int _position = -1;

    public StudentEnumerator(ArrayList tests, ArrayList exams)
    {ів
        var testSubjects = tests.Cast<Test>().Select(t => t.Subject);
        var examSubjects = exams.Cast<Exam>().Select(e => e.Subject);
        _commonSubjects = testSubjects.Intersect(examSubjects).ToList();
    }

    public string Current => _commonSubjects[_position];

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        _position++;
        return _position < _commonSubjects.Count;
    }

    public void Reset() => _position = -1;

    public void Dispose() { }
}