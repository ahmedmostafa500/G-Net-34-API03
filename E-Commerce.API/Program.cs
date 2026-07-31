using E_Commerce.API.Extensions;
using E_Commerce.Apllication;
using E_Commerce.Infrastructure;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddInfraStrucureServices(builder.Configuration);
builder.Services.AddApplicationServices();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
 await app.SeedDatabaseAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseStaticFiles(new StaticFileOptions
    {
    FileProvider=new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath,"Files")),
    RequestPath="/Files"
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
