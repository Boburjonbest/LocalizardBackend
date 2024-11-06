
using FluentAssertions.Common;
using Localizard._context;
using Localizard.Models;
using Localizard.Views.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NgrokExtensions;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Text;




var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;



var key = Encoding.ASCII.GetBytes("Bboburtryhsdfhqw10945738756823Bboburtryhsdfhqw10945738756823");

//Add services to the container.



builder.Services.AddScoped<TokenService>();
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = true;
    options.SaveToken = true;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        //ValidIssuer = builder.Configuration["Jwt:Issuer"],
        //ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))

    };
});
builder.Services.AddControllers();

builder.Services.AddAuthorization(options =>

{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
}

);

//builder.Services.AddAuthorization(options => 
//{
//    options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));

//    options.AddPolicy("CreateUserPermission", policy => policy.RequireClaim("Permission", "CreateUser"));
//    options.AddPolicy("DeleteUserPermission", policy => policy.RequireClaim("Permission", "DeleteUser"));
//    options.AddPolicy("ViewReportsPermissions", policy => policy.RequireClaim("Permission", "ViewReports"));
//});

//builder.Services.AddAuthorization(options =>
//{

//    options.AddPolicy("User", policy => policy.RequireRole("User"));

//});

builder .Services.AddScoped<ProjectService>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });


options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    In = ParameterLocation.Header,
    Description = "������� ����� � ������� **Bearer {��� �����}**",
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    Scheme = "bearer"
});
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});


builder.Services.AddHttpClient<LocalizardService>();
builder.Services.AddControllers();



 
builder.Services.AddCors(p =>
{
    p.AddPolicy("cors", pl =>
    {
        pl.AllowAnyMethod();
        pl.AllowAnyHeader();
        pl.AllowAnyOrigin();
    });

});
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Host = localhost; Port = 5432; Database = localizarddb; Username = postgres; Password = Boburjon2002"));
var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("cors");

app.UseHttpsRedirection();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=EmpClasses}/{action=Index}/{id?}"
    );



app.Run();


// ldqngm15-7118.euw.devtunnels.ms/swagger/index.html
// ldqngm15-7118.euw.devtunnels.ms/swagger/index.html
