using BeachLab.Core.Enums;

namespace BeachLab.Core.Entities;

public class KnowledgeIdea
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Title { get; set; } = "";

    public string Summary { get; set; } = "";

    public string Content { get; set; } = "";

    public KnowledgeCategory Category { get; set; }

    public KnowledgeStatus Status { get; set; }

    public string Author { get; set; } = "";

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public string Notes { get; set; } = "";

    public Guid SourceId { get; set; }

    public List<KnowledgeTag> Tags { get; set; } = new();
}