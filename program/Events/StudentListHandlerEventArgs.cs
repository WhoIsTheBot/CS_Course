public class StudentListHandlerEventArgs : EventArgs
{
    public string CollectionName { get; set; }
    public string ChangeType { get; set; }
    public Student ChangedStudent { get; set; }

    public StudentListHandlerEventArgs(string collectionName, string changeType, Student changedStudent)
    {
        CollectionName = collectionName;
        ChangeType = changeType;
        ChangedStudent = changedStudent;
    }

    public override string ToString()
    {
        return $"Collection: {CollectionName}, Change: {ChangeType}, Student: {ChangedStudent.ToShortString()}";
    }
}