using BlazorSozluk.WebApp;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;
using BlazorSozluk.WebApp.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using BlazorSozluk.WebApp.Infrastructure.Auth;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var env = builder.HostEnvironment;

//builder.Configuration.AddJsonFile(
//    "appsettings.json",
//    optional: false,
//    reloadOnChange: true);

//builder.Configuration.AddJsonFile(
//    $"appsettings.{env.Environment}.json",
//    optional: true,
//    reloadOnChange: true);

builder.Services.AddHttpClient("WebApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:5001");
})
    .AddHttpMessageHandler<AuthTokenHandler>();

builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();

    return clientFactory.CreateClient("WebApiClient");
});

#region Services

builder.Services.AddTransient<IEntryService, EntryService>();
builder.Services.AddTransient<IVoteService, VoteService>();
builder.Services.AddTransient<IFavService, FavService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IIdentityService, IdentityService>();
builder.Services.AddScoped<AuthTokenHandler>();
builder.Services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();

#endregion

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
