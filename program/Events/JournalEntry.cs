public class JournalEntry
{
    public string CollectionName { get; set; }
    public string ChangeType { get; set; }
    public string StudentData { get; set; }

    public JournalEntry(string collectionName, string changeType, string studentData)
    {
        CollectionName = collectionName;
        ChangeType = changeType;
        StudentData = studentData;
    }

    public override string ToString()
    {
        return $"[{CollectionName}] {ChangeType}: {StudentData}";
    }
}