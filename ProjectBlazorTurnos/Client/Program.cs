using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ProjectBlazorTurnos.Client;
using Blazorise;
using Blazorise.Material;
using Blazorise.Icons.Material;
using ProjectBlazorTurnos.Client.Services;
using Radzen;
//using System.Text;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services
    .AddBlazorise(options =>
    {
        options.Immediate = true;
        //options.ChangesTextOnkeyPress = true;
    })
    .AddMaterialProviders()
    .AddMaterialIcons();

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//se agrego al contenedor de dependencias el nuevo servicio
builder.Services.AddScoped<IlistaServicio, listaServicio>();
builder.Services.AddScoped<IgrabarClienteServicio, grabarClienteServicio>();
builder.Services.AddScoped<TooltipService>();

await builder.Build().RunAsync();

