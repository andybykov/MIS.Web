using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using MIS.BLL;
using MIS.Core;
using MIS.Core.InputModels;
using MIS.Core.IRepositories;
using MIS.DAL;
using MIS.Web.Components;
using MIS.Web.IRepositories;
using System.Security.Claims;

namespace MIS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents()
                .AddInteractiveWebAssemblyComponents();
            
            builder.Services.AddAuthorization();
            builder.Services.AddCascadingAuthenticationState();

            builder.Services.AddDbContext<DataContext>(); // что является DataContext во всем приложении
            builder.Services.AddScoped<IUserRepository, UserRepository>(); // создаем репозитории
            builder.Services.AddScoped<UserManager>(); // создаем Сервисы/Менеждеры


            builder.Services.AddScoped<IOrderRepository, OrderRepository>(); // создаем репозитории
            builder.Services.AddScoped<OrderManager>(); // создаем Сервисы/Менеждеры

            builder.Services.AddScoped<IMedicalServiceRepository, MedicalServiceRepository>(); // создаем репозитории
            builder.Services.AddScoped<MedicalServiceManager>(); // создаем Сервисы/Менеждеры



            DataContext data = new DataContext();
            // Проверяет, существует ли БД, соответствующая контексту, и создает БД с таблицами по текущим моделям 
            data.Database.EnsureCreated();


            //builder.Services.AddAutoMapper(cfg =>
            //{
            //    //cfg.AddProfile<MedicalServiceMappingProfile>()
            //    //cfg.AddProfile<UserMappingProfile>();  //профили AutoMapper

            //});           

            //Добавляем авторизацию
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(
                    options =>
                    {
                        //options.Cookie.Name = "auth_token";
                        options.LoginPath = "/login"; // куда редиректит[Authorize], если не залогинен
                        options.AccessDeniedPath = "/denied"; // Если не та роль
                        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
                    });

            builder.Services.AddAuthorization();
            builder.Services.AddCascadingAuthenticationState();
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddHttpClient();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseAntiforgery();

            app.MapRazorComponents<App>()
                .AddInteractiveServerRenderMode()
                .AddInteractiveWebAssemblyRenderMode()
                .AddAdditionalAssemblies(typeof(Client._Imports).Assembly);

            app.Run();
            
        }
    }
}
