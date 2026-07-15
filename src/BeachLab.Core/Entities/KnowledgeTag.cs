namespace BeachLab.Core.Entities;

public class KnowledgeTag
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = "";
}