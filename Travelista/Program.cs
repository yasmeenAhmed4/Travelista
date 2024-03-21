using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Travelista.Areas.Identity.Data;
using Travelista.Data;
using Travelista.GenericRepository;
using Travelista.Models;
using Travelista.PayPalModels;
using Stripe;
using Microsoft.AspNetCore.Identity.UI.Services;
using Travelista.Services;
using Travelista.Helpers;


namespace Travelista
{
	public class Program
	{
		public static async Task Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);
			
			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));
			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

			builder.Services.AddAuthentication()
				.AddGoogle(options =>
				{
					builder.Configuration.Bind("Authentication:Google", options);
				})
				.AddFacebook(options =>
				{
					builder.Configuration.Bind("Authentication:Facebook", options);
				})
				.AddMicrosoftAccount(options =>
				{
					builder.Configuration.Bind("Authentication:Microsoft", options);
				});

			//Adding data to database once it's created
			//SeedData.Seed();

			builder.Services.AddControllersWithViews();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddTransient<IEmailSender, EmailSender>();

			//Stripe
			StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

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


