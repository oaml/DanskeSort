using MediatR;
using SortAPI.CommandHandlers;
using SortAPI.QueryHandlers;
using SortAPI.Services.SortingService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISortingService, BubbleSortService>();
builder.Services.AddMediatR(typeof(SortedNumbersQueryHandler));
builder.Services.AddMediatR(typeof(SortedNumbersCommandHandler));
builder.Services.AddScoped<SortedNumbersQueryHandler>();
builder.Services.AddScoped<SortedNumbersCommandHandler>();

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
