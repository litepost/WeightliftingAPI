//https://medium.com/@fahrican.kcn/mastering-minimal-apis-implementing-layered-architecture-and-repository-pattern-in-net7-3e9c1b31a658

using Microsoft.EntityFrameworkCore;
using WeightliftingAPI;
using static WeightliftingAPI.LiftRoutes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<LiftListDbContext>(options => 
    options.UseSqlite("Data source=WeightliftingDb.db"));

builder.Services.AddScoped<ILiftService, LiftService>();
builder.Services.AddScoped<ILiftRepository, LiftRespository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var apiEndpointsLiftGroup = app.MapGroup("api/lifts");
apiEndpointsLiftGroup.MapGet("/", GetAllLifts);
apiEndpointsLiftGroup.MapGet("/{id}", GetLift);
apiEndpointsLiftGroup.MapGet("/getByLiftName", GetLiftByName);
apiEndpointsLiftGroup.MapPost("/", CreateLift);
apiEndpointsLiftGroup.MapPut("/{id}", UpdateLift);
apiEndpointsLiftGroup.MapDelete("/{id}", DeleteLift);

app.MapGet("/fakeError", FakeError);

app.Run();


