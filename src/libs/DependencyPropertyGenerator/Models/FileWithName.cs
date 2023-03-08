namespace H.Generators;

public readonly record struct FileWithName(
    string Name,
    string Text)
{
    public static FileWithName Empty => new(string.Empty, string.Empty);
    public bool IsEmpty => string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Text);
}
