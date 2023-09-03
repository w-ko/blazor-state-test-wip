using Microsoft.AspNetCore.Components;

namespace Draggable;

public class InMemoryDispatcher
{
    private readonly AppStore _store;

    public InMemoryDispatcher(AppStore store)
    {
        _store = store;
    }
    
    public async Task ExecuteAsync(Commands.AddTodo command)
    {
        var handler = new Commands.AddTodo.Handler(_store);
        await handler.Execute(command);
    }
    
    public async Task ExecuteAsync(Commands.RemoveTodo command)
    {
        var handler = new Commands.RemoveTodo.Handler(_store);
        await handler.Execute(command);
    }

    public async Task ExecuteAsync(Commands.FavouriteTodoItem command)
    {
        var handler = new Commands.FavouriteTodoItem.Handler(_store);
        await handler.Execute(command);
    }
}
