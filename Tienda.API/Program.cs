using System.Configuration;
using Tienda.Business;
using Tienda.DataAccess;
using Tienda.Models;
using Tienda.Models.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<ICarritoBusiness, CarritoBusiness>();
builder.Services.AddTransient<ICarritoDataAccess, CarritoDataAccess>();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Api Tienda Cosméticos - César Giraldo Muñoz",
        Version = "v1"
    });
    //    builder.Services.AddTransient<ITurnosBusiness, TurnosBusiness>();
    var basePath = AppContext.BaseDirectory;
    var assemblyName = System.Reflection.Assembly
                  .GetEntryAssembly().GetName().Name;
    var fileName = Path
                  .GetFileName(assemblyName + ".xml");
    var xmlPath = Path.Combine(basePath, fileName);
    c.IncludeXmlComments(xmlPath);
});
LocalContext.strConn = builder.Configuration.GetConnectionString("ConnStr");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
