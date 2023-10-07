class MathAssignment : Assignment
{
    public string TextbookSection { get; }
    public string Problems { get; }

    public MathAssignment(string studentName, string topic, string textbookSection, string problems)
        : base(studentName, topic)
    {
        this.TextbookSection = textbookSection;
        this.Problems = problems;
    }

    public override string GetSummary()
    {
        return $"Math Assignment for {StudentName} on {Topic}: TextbookSection - {TextbookSection}, Problems - {Problems}";
    }

    public string GetHomeworkList()
    {
        return "Homework: Practice problems 7.1 to 7.5";
    }
}