namespace EFCore.Example.SplitToTable.Entities;

public class Blog
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? MainId { get; set; }

    public virtual Main? Main { get; set; }
}