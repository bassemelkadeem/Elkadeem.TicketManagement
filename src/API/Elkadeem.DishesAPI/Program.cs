using Elkadeem.DishesAPI;
using Elkadeem.TicketManagement.Application.Extensions;
using Elkadeem.TicketManagement.Application.Features.Dishes.Queries.GetDishesListQuery;
using Elkadeem.TicketManagement.Infrastructure.Extensions;
using Elkadeem.TicketManagement.Persistence.Extensions;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/dishes", async (ISender sender) =>
{
    var dishes = await sender.Send(new GetDishesListQuery());
    return dishes;
});

await app.ResetDatabaseAsync();
app.Run();


