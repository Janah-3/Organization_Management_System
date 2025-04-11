using Microsoft.EntityFrameworkCore;
using Demo.DataAccess.Data.contexts;
using Demo.BusinessLogic.Services;
using Demo.DataAccess.Repositories.classes;
using Demo.DataAccess.Repositories.interfaces;
using Demo.BusinessLogic.Profiles;
using Microsoft.AspNetCore.Mvc;
using Demo.DataAccess.Repositories;
using Demo.BusinessLogic.Services.AttachmentServices;


namespace Demo.Presntation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.

            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute()); //action method to prevent cross site forgery attacks
            }); 
            builder.Services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));//2. register to services in the container
                options.UseLazyLoadingProxies();
            });

            builder.Services.AddScoped<DepartmentRepo>();//3. register to services in the container
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepo>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddAutoMapper(m=> m.AddProfile(new MappingProfile()));
            //builder.Services.AddScoped<IWebHostEnvironment >
            builder.Services.AddScoped<IAttachmentService, AttachmentService>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();


            #endregion

            var app = builder.Build();


            #region Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

          

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        } 
        #endregion
    }
}
