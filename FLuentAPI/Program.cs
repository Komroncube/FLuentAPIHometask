using FLuentAPI.DataContext;
using FLuentAPI.ExtensionMiddlewares;
using FLuentAPI.Middlewares;
using FLuentAPI.Services.AuthServices;
using FLuentAPI.Services.TokenServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json.Serialization;

namespace FLuentAPI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //    .AddJwtBearer(options=>
        //    {
        //        options.TokenValidationParameters = new TokenValidationParameters
        //        {
        //            //kim tomonidan berildi
        //            ValidateIssuer = true,
        //            //kimga berildi
        //            ValidateAudience = true,
        //            //qancha muddatga berildi
        //            ValidateLifetime = true,
        //            //secret keyni tekshirish
        //            ValidAudience = builder.Configuration["JWT:ValidAudience"],
        //            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        //            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:SecretKey"]))
        //        };
        //    });

        builder.Services.AddControllers();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddSingleton<ITokenService, TokenService>();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        //builder.Services.AddSwaggerGen(options =>
        //{
        //    options.SwaggerDoc("V1", new OpenApiInfo
        //    {
        //        Version = "v1",
        //        Title = "BookstoreAuth",

        //    });

        //    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
        //    {
        //        Scheme = "Beared",
        //        BearerFormat = "JWT",
        //        Type = SecuritySchemeType.Http
        //    });

        //    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
        //    {
        //        {
        //            new OpenApiSecurityScheme()
        //            {
        //                Reference = new OpenApiReference()
        //                {
        //                    Id = "Bearer",
        //                    Type = ReferenceType.SecurityScheme
        //                }
        //            },
        //            new List<string>()
        //        }
        //    });
        //});

        builder.Services.AddSwaggerGen();
        builder.Services.AddControllersWithViews()
                        .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
        builder.Services.AddDbContext<BookstoreDBContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));






        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(/*options =>
            {
                options.SwaggerEndpoint("/swagger/V1/swagger.json", "Auth Demo API");
            }*/);
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();
        //app.ConfigureRedirectionMap();

        app.Run();
    }
}