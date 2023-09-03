using System.Collections.Specialized;
using Microsoft.AspNetCore.Components;

namespace Draggable.Shared;

public class StatefulLayoutComponentBase: LayoutComponentBase, IDisposable
{
    [Inject] public AppStore AppStore { get; set; } = default!;

    protected override void OnInitialized()
    {
        AppStore.States.CollectionChanged += OnStatesOnCollectionChanged;
        base.OnInitialized();
    }

    private void OnStatesOnCollectionChanged(object? sender, NotifyCollectionChangedEventArgs args) => StateHasChanged();

    public void Dispose()
    {
        AppStore.States.CollectionChanged -= OnStatesOnCollectionChanged;
    }
}
