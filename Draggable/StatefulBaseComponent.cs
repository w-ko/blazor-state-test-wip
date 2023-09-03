using System.Collections.Specialized;
using Microsoft.AspNetCore.Components;

namespace Draggable;

public class StatefulBaseComponent : ComponentBase, IDisposable
{
    [Inject] public AppStore AppStore { get; set; } = default!;

    protected override void OnInitialized()
    {
        AppStore.OnStateChanged += AppStoreOnOnStateChanged;
        base.OnInitialized();
    }

    private async void AppStoreOnOnStateChanged() => await InvokeAsync(StateHasChanged);

    public void Dispose()
    {
        AppStore.OnStateChanged -= AppStoreOnOnStateChanged;
    }
}
