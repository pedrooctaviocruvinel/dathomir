using Dathomir.Backoffice.Infrastructure.DependencyInjection;
using Dathomir.Backoffice.Presentation.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwagger(builder.Configuration);
builder.Services.AddDependencies(builder.Configuration);

var app = builder.Build();

app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
