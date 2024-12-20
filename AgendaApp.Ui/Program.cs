using AgendaApp.Ui;
using AgendaApp.UI;
using AgendaApp.UI.Interceptors;
using AgendaApp.UI.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

/*
 * Configuração da biblioteca HTTP CLIENT 
 * para executar os serviços da API
 */
builder.Services.AddScoped(sp => new HttpClient());

/*
 * Configuração da biblioteca Blazored LocalStorage
 */
builder.Services.AddBlazoredLocalStorage();

/*
 * Configuração para injeções de dependência
 */
builder.Services.AddScoped<AuthService>();

/*
 * Configuração para o Interceptor
 */
builder.Services.AddScoped<AuthInterceptor>();

await builder.Build().RunAsync();



