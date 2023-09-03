namespace Draggable;

public abstract class CommandHandler<TCommand>
{
    protected readonly AppStore Store;

    public CommandHandler(AppStore store) => Store = store;

    internal async Task Execute(TCommand command)
    {
        await Handle(command);
        Store.Notify();
    }
    
    public abstract Task Handle(TCommand command);
}
