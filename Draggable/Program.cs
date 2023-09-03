using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Draggable;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<AppStore>();
builder.Services.AddScoped<Commands.AddTodo.Handler>();
builder.Services.AddScoped<Commands.RemoveTodo.Handler>();
builder.Services.AddScoped<Commands.FavouriteTodoItem.Handler>();
builder.Services.AddScoped<InMemoryDispatcher>();

await builder.Build().RunAsync();
