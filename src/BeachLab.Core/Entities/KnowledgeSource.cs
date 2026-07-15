using BeachLab.Core.Enums;

namespace BeachLab.Core.Entities;

public class KnowledgeSource
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public SourceType SourceType { get; set; }

    public string Title { get; set; } = "";

    public string OriginalFilePath { get; set; } = "";

    public string TranscriptFilePath { get; set; } = "";

    public DateTime CapturedAt { get; set; } = DateTime.Now;

    public string Description { get; set; } = "";
}