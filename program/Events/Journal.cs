public class Journal
{
    private List<JournalEntry> _entries = new List<JournalEntry>();

    public void StudentCollectionChanged(object sender, StudentListHandlerEventArgs args)
    {
        _entries.Add(new JournalEntry(
            args.CollectionName,
            args.ChangeType,
            args.ChangedStudent.ToShortString()));
    }

    public override string ToString()
    {
        return string.Join("\n", _entries);
    }
}