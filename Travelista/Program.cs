using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Travelista.Areas.Identity.Data;
using Travelista.Data;
using Travelista.GenericRepository;
using Travelista.Models;


using Travelista.Helpers;

using Travelista.PayPalModels;


namespace Travelista
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			

			builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
				.AddEntityFrameworkStores<ApplicationDbContext>();

		

			builder.Services.AddScoped<IGenericRepository<Trip>, GenericRepository<Trip>>();

			builder.Services.AddScoped<IGenericRepository<Contact>, GenericRepository<Contact>>();


			builder.Services.AddControllersWithViews();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            builder.Services.AddControllersWithViews();


            builder.Services.AddScoped<IGenericRepository<TripType>, GenericRepository<TripType>>();
            builder.Services.AddScoped<IGenericRepository<Country>, GenericRepository<Country>>();
            builder.Services.AddScoped<IGenericRepository<Image>, GenericRepository<Image>>();
            builder.Services.AddScoped<IGenericRepository<Trip>, GenericRepository<Trip>>();

            var app = builder.Build();

			
			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();


			app.MapAreaControllerRoute(
			name: "Admin",
			areaName: "Admin",
			pattern: "Admin/{controller=Admin}/{action=Index}/{id?}");

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}
	}
}
