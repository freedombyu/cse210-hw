using System;

class Assignment
{
    public string StudentName { get; }
    public string Topic { get; }

    public Assignment(string studentName, string topic)
    {
        StudentName = studentName;
        Topic = topic;
    }

    public virtual string GetSummary()
    {
        return $"Assignment for {StudentName} on {Topic}";
    }
}