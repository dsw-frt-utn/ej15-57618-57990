using Dsw2026Ej15.Api.Middelware;
using Dsw2026Ej15.Data;
using Dsw2026Ej15.Domain;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();


builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

builder.Services.AddSingleton<IPersistence, PersistenceInMemory>();

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
