using Dsw2026Ej15.Api.Middelware;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=Dsw2026Ej15;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True";
builder.Services.AddDbContext<Dsw2026Ej15DbContext>(options => {
   
    options.UseSqlServer(connectionString);

});
builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

builder.Services.AddScoped<IPersistence, PercistenceEf>();

var app = builder.Build();



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
