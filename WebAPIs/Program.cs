using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using VinilProjeto.Repository;
using VinilProjeto.Repository.AdminRepository;
using VinilProjeto.Repository.UsuarioCompradorRepository;
using VinilProjeto.Repository.VinilRepository;
using VinilProjeto.UseCase.AdminUseCase.CadastrarAdmin;
using VinilProjeto.UseCase.AdminUseCase.GetAdmin;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.GetAdminPerfil;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.GetUsuarioComprador;
using VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;
using WebAPIs.Config;
using WebAPIs.Service.LoginServiceAdmin;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseUrls("https://0.0.0.0:7048;http://0.0.0.0:5288");

builder.Services.AddCors(opt =>
{
    opt.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyHeader();
            policy.AllowAnyMethod();
        });
});

builder.Services.AddScoped<DataBaseContext, DataBaseContext>();


builder.Services.AddScoped<IAdminRepository, EFCoreAdminRepository>();
builder.Services.AddScoped<ILoginServiceAdmin, LoginService>();
builder.Services.AddScoped<ICadastrarAdminUseCase, CadastrarAdminUseCase>();
builder.Services.AddScoped<IGetAdminUseCase, GetAdminUseCase>();
builder.Services.AddScoped<IGetAdminPerfilUseCase, GetAdminPerfilUseCase>();


builder.Services.AddScoped<IUsuarioCompradorRepository, EFCoreUsuarioCompradorRepository>();
builder.Services.AddScoped<ICadastrarUsuarioCompradorUseCase, CadastrarUsuarioCompradorUseCase>();
builder.Services.AddScoped<IGetUsuarioCompradorUseCase, GetUsuarioCompradorUseCase>();

builder.Services.AddScoped<IVinilRespository, EFCoreVinilRepository>();
builder.Services.AddScoped<ICadastrarVinilUseCase, CadastrarVinilUseCase>();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() 
    { 
        Name = "Authorization", 
        Type = SecuritySchemeType.ApiKey, 
        Scheme = "Bearer", 
        BearerFormat = "JWT", 
        In = ParameterLocation.Header, 
        Description = "JWT Authorization header using the Bearer scheme. " +
                      "\r\n\r\n Enter 'Bearer' [space] and then your token in the text input below." +
                      "\r\n\r\nExample: \"Bearer 12345abcdef\"", 
    }); 
    c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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

//Converting enums to string description
builder.Services
    .AddControllersWithViews()
    .AddNewtonsoftJson(options => 
        options
            .SerializerSettings
            .Converters
            .Add(new StringEnumConverter())
    );

builder.Services.AddSwaggerGenNewtonsoftSupport();
builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(
        options =>
        {
            var key = Encoding.ASCII.GetBytes(JwtConfig.Secret);
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = false,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
    );

var app = builder.Build();
app.UseCors();

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