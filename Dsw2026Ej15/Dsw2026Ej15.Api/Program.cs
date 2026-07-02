using Dsw2026Ej15.Api.Middelware;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain;
using Dsw2026Ej15.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Dsw2026Ej15.Data.Helpers;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Dsw2026Ej15DbContext>(options => {

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));


});
builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

builder.Services.AddScoped<IPersistence, PercistenceEf>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<Dsw2026Ej15DbContext>();
context.SeedworkSpecialities(@"specialities.json");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseHttpsRedirection();



app.UseAuthorization();


app.MapControllers();
app.MapHealthChecks("/health-check");
app.Run();
