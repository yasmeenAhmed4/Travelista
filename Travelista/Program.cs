using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Travelista.Areas.Identity.Data;
using Travelista.Data;
using Travelista.Services;
using Travelista.GenericRepository;
using Travelista.Models;
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

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            builder.Services.AddAuthentication()
                .AddGoogle(options =>
                {
                    options.ClientId = "772354289034-g46j7pn553arv79nj8218sf44chpr69c.apps.googleusercontent.com";
                    options.ClientSecret = "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";

                })
                .AddFacebook(options =>
                {
                    options.ClientId ="763692572369800";
                    options.ClientSecret ="368629d482c449c8bc16b064f9839086";
                })
                .AddMicrosoftAccount(options =>
                {
                	options.ClientId = "6449bac4-c6aa-47c5-9a0c-9a35bd642724";
                	options.ClientSecret = "wlm8Q~XLe4C7Un9deZN8XA75itDAeDdLsDGx3alm";

        		});

			//Adding data to database once it's created
			//SeedData.Seed();
			

			//builder.Services.AddScoped<UserManager<ApplicationUser>>();
			//builder.Services.AddScoped<SignInManager<ApplicationUser>>();


			builder.Services.AddControllersWithViews();
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.AddTransient<IEmailSender, EmailSender>();



			builder.Services.AddSingleton(x =>
			new PayPalClient(builder.Configuration["PayPalOptions:ClientId"] ,
			builder.Configuration["PayPalOptions:ClientSecret"],
			builder.Configuration["PayPalOptions:Mode"])
			);
			
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
