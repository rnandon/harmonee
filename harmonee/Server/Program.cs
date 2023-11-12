using harmonee.Server.Data;
using harmonee.Shared.Data;
using Microsoft.EntityFrameworkCore;

namespace harmonee
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            var options = new DbContextOptionsBuilder();
            var familyConnectionString = builder.Configuration.GetConnectionString("Family");
            builder.Services.AddScoped(_ => new FamilyContext(familyConnectionString));
            builder.Services.AddScoped(_ => new FamilyMemberContext(familyConnectionString));
            builder.Services.AddScoped(_ => new FamilyEventContext(familyConnectionString));
            builder.Services.AddScoped(_ => new FamilyListContext(familyConnectionString));
            builder.Services.AddScoped<IFamilyRepository, FamilyRepository>();
            builder.Services.AddScoped<IFamilyMemberRepository, FamilyMemberRepository>();
            builder.Services.AddScoped<IFamilyEventRepository, FamilyEventRepository>();
            builder.Services.AddScoped<IFamilyListRepository, FamilyListRepository>();

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

            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();


            app.MapRazorPages();
            app.MapControllers();
            app.MapFallbackToFile("index.html");

            app.Run();
        }
    }
}
