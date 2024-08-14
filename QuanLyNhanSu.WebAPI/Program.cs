using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using QuanLyNhanSu.Business.Interfaces;
using QuanLyNhanSu.Business.Services;
using QuanLyNhanSu.Data.Context;
using QuanLyNhanSu.Data.Interfaces;
using QuanLyNhanSu.Data.Repositories;
using QuanLyNhanSu.Models.Entities;


namespace QuanLyNhanSu.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<QLNSContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("QuanLyNhanSu.WebAPI")));
            builder.Services.AddIdentity<User,Role>()
            .AddEntityFrameworkStores<QLNSContext>()
            .AddDefaultTokenProviders();


            // Add services to the container.
            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            builder.Services.AddScoped(typeof(IScheduleRepository<>), typeof(ScheduleRepository<>));
            builder.Services.AddScoped<IScheduleService, ScheduleService>();
            builder.Services.AddScoped(typeof(IAccountRepository<>), typeof(AccountRepository<>));
            builder.Services.AddTransient<IAccountService, AccountService>();
            builder.Services.AddTransient<UserManager<User>, UserManager<User>>();
            builder.Services.AddTransient<SignInManager<User>, SignInManager<User>>();
            builder.Services.AddTransient<RoleManager<Role>, RoleManager<Role>>();
            builder.Services.AddScoped<ISalaryRepository, SalaryRepository>();
            builder.Services.AddScoped<ISalaryService, SalaryService>();
            builder.Services.AddScoped<IHeSorepository, HeSoRepository>();
            builder.Services.AddScoped<IHeSoService, HeSoService>();
            builder.Services.AddScoped<IPhucLoiRepository, PhucLoiRepository>();
            builder.Services.AddScoped<IPhucLoiService, PhucLoiService>();
            builder.Services.AddScoped<IPositionService, PositionService>();
            builder.Services.AddScoped<IAccountService, AccountService>();
            //builder.Services.AddScoped<IUserService, UserService>();


            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    });
            });
            var app = builder.Build();
            app.UseCors("AllowAllOrigins");
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.UseAuthentication();

            app.MapControllers();

            app.Run();
        }
    }
}