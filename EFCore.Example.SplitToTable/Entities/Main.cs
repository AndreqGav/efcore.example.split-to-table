namespace EFCore.Example.SplitToTable.Entities;

public class Main
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual Details? Details { get; set; }

    public Blog? Blog { get; set; }
}