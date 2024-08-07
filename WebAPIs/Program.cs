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
using VinilProjeto.UseCase.UsuarioCompradorUseCase.AdicionarVinilFavorito;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.AtivarContaUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.CadastrarUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.GetAdminPerfil;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.GetPerfilUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.GetUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.MandarEmailPergunta;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarDesativarStatusUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarStatusUsuarioComprador;
using VinilProjeto.UseCase.UsuarioCompradorUseCase.UpdateUsuarioComprador.AtualizarTelefone;
using VinilProjeto.UseCase.VinilUseCase.CadastrarVinil;
using VinilProjeto.UseCase.VinilUseCase.DeleteImagem;
using VinilProjeto.UseCase.VinilUseCase.DeleteVinil;
using VinilProjeto.UseCase.VinilUseCase.DeleteVinisFavoritosUsuarioComprador;
using VinilProjeto.UseCase.VinilUseCase.GetTodosVinil;
using VinilProjeto.UseCase.VinilUseCase.GetVinisFavoritosUsuarioComprador;
using WebAPIs.Config;
using WebAPIs.Controller.VinilController;
using WebAPIs.Service.GoogleCloudStorageService;
using WebAPIs.Service.LoginServiceAdmin;
using WebAPIs.Service.LoginServiceUsuarioComprador;
using LoginService = WebAPIs.Service.LoginServiceAdmin.LoginService;

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
builder.Services.AddScoped<ILoginServiceUsuarioComprador, LoginServiceUsuarioComprador>();
builder.Services.AddScoped<IPutUsuarioCompradorTelefoneUseCase, PutUsuarioCompradorTelefoneUseCase>();
builder.Services.AddScoped<IGetPerfilUsuarioCompradorUseCase, GetPerfilUsuarioCompradorUseCase>();
builder.Services.AddScoped<IPutUsuarioCompradorAtivarStatusUseCase, PutUsuarioCompradorAtivarStatusUseCase>();
builder.Services.AddScoped<IPutUsuarioCompradorDesativarStatusUseCase, PutUsuarioCompradorDesativarStatusUseCase>();
builder.Services.AddScoped<IAtivarUsuarioCompradorUseCase, AtivarUsuarioCompradorUseCase>();
builder.Services.AddScoped<IMandarEmailPerguntaUseCase, MandarEmailPerguntaUseCase>();
builder.Services.AddScoped<IAdicionarVinilFavoritoUseCase, AdicionarVinilFavoritoUseCase>();
builder.Services.AddScoped<IGetVinisFavoritosUsuarioCompradorUseCase, GetVinisFavoritosUsuarioCompradorUseCase>();
builder.Services.AddScoped<IDeleteVinisFavoritosUsuarioCompradorUseCase, DeleteVinisFavoritosUsuarioCompradorUseCase>();

builder.Services.AddScoped<IVinilRespository, EFCoreVinilRepository>();
builder.Services.AddScoped<ICadastrarVinilUseCase, CadastrarVinilUseCase>();
builder.Services.AddScoped<IGetTodosVinilUseCase, GetTodosVinilUseCase>();
builder.Services.AddScoped<IPostImagemVinilUseCase, PostImagemVinilUseCase>();
builder.Services.AddScoped<IDeleteImagemVinilUseCase, DeleteImagemVinilUseCase>();
builder.Services.AddScoped<IDeleteVinilUseCase, DeleteVinilUseCase>();



// Add services to the container.
builder.Services.AddControllers();

builder.Services.Configure<GCSConfigOptions>(builder.Configuration);

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

//Google Service

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();