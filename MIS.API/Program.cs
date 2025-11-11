
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MIS.BLL;
using MIS.Core;
using MIS.Core.IRepositories;
using MIS.DAL;
using MIS.Web.IRepositories;
using System.Reflection;
using System.Security.Claims;
using System.Text;


namespace MIS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1.0", new OpenApiInfo
                {
                    Title = "MIS Medical Services API",
                    Version = "v1.0",
                    Description = "JWT-secured REST API. Authorize from authentication endpoint"
                });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Bearer {token}\"", // !!! СИГНАТУРА !!!
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
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
                        Array.Empty<string>()
                    }
            });

                

                // Включаем XML-комментарии
                var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });

            builder.Services.AddDbContext<DataContext>(); 
            builder.Services.AddScoped<IUserRepository, UserRepository>(); 
            builder.Services.AddScoped<UserManager>(); 


            builder.Services.AddScoped<IOrderRepository, OrderRepository>(); 
                builder.Services.AddScoped<OrderManager>(); 

            builder.Services.AddScoped<IMedicalServiceRepository, MedicalServiceRepository>();
            builder.Services.AddScoped<MedicalServiceManager>(); 


            DataContext data = new DataContext();
            
            data.Database.EnsureCreated();

            //builder.Services.AddAuthentication().AddCookie();
            // Авторизация
            builder.Services.AddAuthorization();
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,  
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = "Issuer",
                        ValidAudience = "ForMyApp",
                        IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("mysupersecretkey_32bytes_long!!!!!")),

                        // тип claim 
                        RoleClaimType = ClaimTypes.Role
                    };


                });



            var app = builder.Build();

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
        }
    }
}
