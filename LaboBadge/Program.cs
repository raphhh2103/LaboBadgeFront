using LaboBadge;
using LaboBadge.Services;
using LaboBadge.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.JSInterop;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.UseCors(policy =>
//    policy.WithOrigins("http://localhost:5000", "https://localhost:5001")
//    .AllowAnyMethod()
//    .WithHeaders(HeaderNames.ContentType));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddTransient(typeof(UserServices));
builder.Services.AddScoped<SessionStorageAccessor>();
builder.Services.AddTransient(typeof(EquipmentServices));
//builder.Services.AddTransient(typeof(Storage));

await builder.Build().RunAsync();
