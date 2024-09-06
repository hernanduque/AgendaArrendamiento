using Microsoft.AspNetCore.ResponseCompression;
using Oracle.ManagedDataAccess.Client;
using ProjectBlazorTurnos.Client.Services;
using ProjectBlazorTurnos.Server.Context;
using ProjectBlazorTurnos.Server.Repositories;
using ProjectBlazorTurnos.Server.Service;
using ProjectBlazorTurnos.Server.SingnaIR;
using Repositorio;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSignalR();
builder.Services.AddHostedService<TimeWorker>();

///////////////////variable de session//////////////////////////////////////
//builder.Services.AddDistributedMemoryCache();

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromSeconds(10);
//    options.Cookie.HttpOnly = true;
//    options.Cookie.IsEssential = true;
//});
///////////////////variable de session//////////////////////////////////////

//INYECTAMOS LA
builder.Services.AddSingleton<IDbConnection>((sp) => new SqlConnection(builder.Configuration.GetConnectionString("CONEXIONSQL")));
builder.Services.AddSingleton<DapperContext>();
//builder.Services.AddSingleton<IDbConnection>((sp) => new OracleConnection(builder.Configuration.GetConnectionString("CONEXIONORACLE")));
//builder.Services.AddSingleton<DapperContext>();

var emailConfig = builder.Configuration
.GetSection("EmailConfiguration")
.Get<EmailConfiguration>();
builder.Services.AddSingleton(emailConfig);

//se agrego al contenedor de dependencias el nuevo servicio
builder.Services.AddScoped<IGrabarClientes, GrabarClientes>();
builder.Services.AddScoped<IListasRepositorio, ListaRepositorio>();
builder.Services.AddScoped<IServicioCliente, ServicioCliente>();
builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddTransient<IEmailSenderCancel, EmailSenderCancel>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.MapHub<ReportHub>("/reports");

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

/////////////////////////////variable de session/////////////////
//app.UseSession();
/////////////////////////////variable de session/////////////////

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
