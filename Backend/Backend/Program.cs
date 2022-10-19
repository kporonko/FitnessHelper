using Backend.Core.Interfaces;
using Backend.Core.Services;
using Backend.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Authority = "http://localhost:7199"; // Your Identity Server URL
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      builder =>
                      {
                          builder.WithOrigins("http://localhost:3000", "http://localhost:3001", "http://localhost:8080").AllowAnyHeader().AllowAnyMethod();
                      });
});
//builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
//{
//    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
//}));

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
builder.Services.AddTransient<IAchievmentService, AchievmentService>();
builder.Services.AddTransient<IUserMusclesService, UserMusclesService>();

var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
