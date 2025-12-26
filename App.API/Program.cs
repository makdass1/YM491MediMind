using App.Repository;
using App.Repository.Extensions;
using App.Service.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;



var builder = WebApplication.CreateBuilder(args);

// 🔥 1) Ayarları appsettings'ten oku (Docker için doğru yol)
var authSettings = builder.Configuration.GetSection("JwtOptions");
var metadataAddress = authSettings["MetadataAddress"];
var validIssuer = authSettings["ValidIssuer"];

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddHttpClient<KeycloakAdminService>();
builder.Services.AddHttpClient<KeycloakAuthService>();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
builder.Services.AddControllers();

// 🔥 Swagger JWT Ayarı
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MediMind API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Bearer {TOKEN}"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
    {
        new OpenApiSecurityScheme {
            Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
        },
        new string[] {}
    }});
});

// 🔥 2) ***TEK BİR JWT AUTHENTICATION*** (Problem buradaydı)
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        // Docker içinden Keycloak metadata’sı
        options.MetadataAddress = metadataAddress;
        options.RequireHttpsMetadata = false;

        // Token Doğrulama
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = false, // Keycloak ANCAK böyle çalışır

            // Token localhost der → API keycloak ağı der
            ValidIssuer = validIssuer,
            ClockSkew = TimeSpan.Zero
        };
    });


builder.Services.AddRepository(builder.Configuration);
// Authorization
builder.Services.AddAuthorization();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
