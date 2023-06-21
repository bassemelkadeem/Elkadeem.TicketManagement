using Elkadeem.CourseLibraryAPI;
using Elkadeem.TicketManagement.Application.Extensions;
using Elkadeem.TicketManagement.Infrastructure.Extensions;
using Elkadeem.TicketManagement.Persistence.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.ResetDatabaseAsync();

app.Run();
