using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.Testing.Features.Services;

namespace WebApplication1.Testing.Features
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services
                .AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryApiResources(Configurations.Apis)
                .AddInMemoryClients(Configurations.Clients)
                .AddInMemoryIdentityResources(Configurations.IdentityResources())
                .AddResourceOwnerValidator<UserPasswordValidator>();

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

            var app = builder.Build();

            // Add useful middleware.
            app.UseIdentityServer();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}