class WritingAssignment : Assignment
{
    public string title { get; }

    public WritingAssignment(string studentName, string topic, string essayTopic)
        : base(studentName, topic)
    {
        title = title;
    }

    public override string GetSummary()
    {
        return $"Writing Assignment for {StudentName} on {Topic}: Title - {title}";
    }

    public string GetWritingInformation()
    {
        return "Writing Information: Remember to include proper citations and references.";
    }
}