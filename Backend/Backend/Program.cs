using Backend.Core.Interfaces;
using Backend.Core.Services;
using Backend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Data Source=localhost\\SQLSERVER;Initial Catalog=TrainingHelperAlevel;Integrated Security=True;MultipleActiveResultSets=true"));
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IBasicSetService, BasicSetService>();
builder.Services.AddTransient<IUserSetService, UserSetService>();
builder.Services.AddTransient<IExerciseService, ExerciseService>();
builder.Services.AddTransient<IMuscleService, MuscleService>();
builder.Services.AddTransient<IProfileService, ProfileService>();
builder.Services.AddTransient<ITrainingService, TrainingService>();

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
