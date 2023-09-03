namespace Draggable;

public class TodoItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Description { get; set; } = string.Empty;
    public bool IsDone { get; set; }
}
