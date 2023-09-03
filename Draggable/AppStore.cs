using System.Collections.ObjectModel;

namespace Draggable;

public record AppStore
{
    public ObservableCollection<IState> States { get; } = default!;
    public AppStore() => States = new ObservableCollection<IState> { new TodoState() };
    public event Action? OnStateChanged;

    public T GetState<T>() where T : IState
    {
        return States.OfType<T>().First();
    }

    // public void SetState<T>(T state) where T : IState
    // {
    //     States[States.IndexOf(States.OfType<T>().First())] = state;
    // }

    public void Notify() => OnStateChanged?.Invoke();
}
