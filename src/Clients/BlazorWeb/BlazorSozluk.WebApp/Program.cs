using BlazorSozluk.WebApp;
using BlazorSozluk.WebApp.Infrastructure.Services.Interfaces;
using BlazorSozluk.WebApp.Infrastructure.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.LocalStorage;

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

var baseUrl = "https://localhost:5001";
builder.Services.AddHttpClient("WebApiClient", client =>
{
    client.BaseAddress = new Uri(baseUrl);
    //TODO AuthTokenHandler will be here
});

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

#endregion

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
