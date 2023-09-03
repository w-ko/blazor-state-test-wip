namespace Draggable;

public record TodoState: IState
{
    public List<TodoItem> Todos { get; private set; } = new();
    public TodoItem? Favorite { get; set; }
}
