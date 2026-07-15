using BeachLab.Core.Entities;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace BeachLab.Core.Services;

public class MarkdownKnowledgeService
{
    private readonly string _knowledgeRootPath;

    public MarkdownKnowledgeService(string knowledgeRootPath)
    {
        if (string.IsNullOrWhiteSpace(knowledgeRootPath))
        {
            throw new ArgumentException(
                "La ruta de conocimiento no puede estar vacía.",
                nameof(knowledgeRootPath));
        }

        _knowledgeRootPath = knowledgeRootPath;
    }

    public string Save(KnowledgeIdea idea)
    {
        ArgumentNullException.ThrowIfNull(idea);

        ValidateIdea(idea);

        idea.UpdatedAt = DateTime.Now;

        string categoryFolderName = ToSafeName(idea.Category.ToString());
        string categoryFolderPath = Path.Combine(
            _knowledgeRootPath,
            categoryFolderName);

        Directory.CreateDirectory(categoryFolderPath);

        string fileName = $"{ToSafeName(idea.Title)}.md";
        string filePath = Path.Combine(categoryFolderPath, fileName);

        string markdown = BuildMarkdown(idea);

        File.WriteAllText(
            filePath,
            markdown,
            new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));

        return filePath;
    }

    private static void ValidateIdea(KnowledgeIdea idea)
    {
        if (string.IsNullOrWhiteSpace(idea.Title))
        {
            throw new InvalidOperationException(
                "La idea debe tener un título.");
        }

        if (string.IsNullOrWhiteSpace(idea.Content))
        {
            throw new InvalidOperationException(
                "La idea debe tener contenido.");
        }
    }

    private static string BuildMarkdown(KnowledgeIdea idea)
    {
        StringBuilder builder = new();

        builder.AppendLine("---");
        builder.AppendLine($"id: {idea.Id}");
        builder.AppendLine($"titulo: \"{EscapeYaml(idea.Title)}\"");
        builder.AppendLine($"categoria: {idea.Category}");
        builder.AppendLine($"estado: {idea.Status}");
        builder.AppendLine($"autor: \"{EscapeYaml(idea.Author)}\"");
        builder.AppendLine($"fuente_id: {idea.SourceId}");
        builder.AppendLine(
            $"creado: {idea.CreatedAt:yyyy-MM-ddTHH:mm:ss}");
        builder.AppendLine(
            $"actualizado: {idea.UpdatedAt:yyyy-MM-ddTHH:mm:ss}");
        builder.AppendLine("---");
        builder.AppendLine();

        builder.AppendLine($"# {idea.Title}");
        builder.AppendLine();

        builder.AppendLine("## Resumen");
        builder.AppendLine();
        builder.AppendLine(
            string.IsNullOrWhiteSpace(idea.Summary)
                ? "_Sin resumen._"
                : idea.Summary.Trim());
        builder.AppendLine();

        builder.AppendLine("## Desarrollo");
        builder.AppendLine();
        builder.AppendLine(idea.Content.Trim());
        builder.AppendLine();

        builder.AppendLine("## Etiquetas");
        builder.AppendLine();

        if (idea.Tags.Count == 0)
        {
            builder.AppendLine("_Sin etiquetas._");
        }
        else
        {
            builder.AppendLine(
                string.Join(
                    ", ",
                    idea.Tags
                        .Where(tag => !string.IsNullOrWhiteSpace(tag.Name))
                        .Select(tag => tag.Name.Trim())));
        }

        builder.AppendLine();

        builder.AppendLine("## Notas del entrenador");
        builder.AppendLine();
        builder.AppendLine(
            string.IsNullOrWhiteSpace(idea.Notes)
                ? "_Sin notas._"
                : idea.Notes.Trim());

        return builder.ToString();
    }

    private static string ToSafeName(string value)
    {
        string normalized = value
            .Trim()
            .ToLowerInvariant()
            .Normalize(NormalizationForm.FormD);

        StringBuilder builder = new();

        foreach (char character in normalized)
        {
            UnicodeCategory category =
                CharUnicodeInfo.GetUnicodeCategory(character);

            if (category != UnicodeCategory.NonSpacingMark)
            {
                builder.Append(character);
            }
        }

        string withoutAccents = builder
            .ToString()
            .Normalize(NormalizationForm.FormC);

        string safeName = Regex.Replace(
            withoutAccents,
            @"[^a-z0-9]+",
            "-");

        return safeName.Trim('-');
    }

    private static string EscapeYaml(string value)
    {
        return (value ?? string.Empty)
            .Replace("\\", "\\\\")
            .Replace("\"", "\\\"");
    }
}