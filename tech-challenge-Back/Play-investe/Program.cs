using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Play_investe.Interface;
using Play_investe.Repository;
using Play_investe.Interface;
using Play_investe.Logging;
using Play_investe.Repository;
using Play_investe.Services;
using System.Reflection;
using System.Text;
using UserTemplate.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Play Investe",
        Version = "v1",
        Description = "API User Template, oferece uma estrutura coesa para gerenciar informa��es de usu�rio, documenta��o clara por meio do Swagger e implementa��o segura de autentica��o JWT, proporcionando uma solu��o robusta para as necessidades de gerenciamento de usu�rios em um sistema."
    });

   // var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    //c.IncludeXmlComments(xmlPath);

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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

builder.Services.AddScoped<IUserRepository, EFUserRepository>();
builder.Services.AddScoped<IAccountRepository, EFAccountRepository>();
builder.Services.AddScoped<IAddressRepository, EFAddressRepository>();
builder.Services.AddScoped<IBoundRepository, EFABoundRepository>();
builder.Services.AddScoped<IInvestimentRepository, EFAInvestimentRepository>();
builder.Services.AddScoped<ITransactionsBankRepository, EFATransactionsBankRepository>();

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddDbContext<ApplicationDbContext>(ServiceLifetime.Scoped);
builder.Services.AddScoped<PasswordHasherService>();

builder.Logging.ClearProviders();
builder.Logging.AddProvider(new CustomLoggerProvider(new CustomLoggerProviderConfiguration()
{
    LogLevel = LogLevel.Information
}));

var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();

var key = Encoding.ASCII.GetBytes(configuration.GetValue<string>("SecretKey"));

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseCors(x => x
                  .AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader());
}



app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
