using FastShop.Data;
using FastShop.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastShop
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			string connection = Configuration.GetConnectionString("DefaultConnection");

			services.AddDbContext<AppDbContext>(options => {
				options.UseSqlServer(connection);
			});

			services.AddSession();

			services.AddIdentity<User, IdentityRole>(opts => {
				opts.Password.RequiredLength = 7;
				opts.Password.RequireLowercase = false;
				opts.Password.RequireUppercase = false;
				opts.Password.RequireDigit = false;
				opts.Password.RequireNonAlphanumeric = false;
				opts.User.RequireUniqueEmail = true;
			})
				.AddEntityFrameworkStores<AppDbContext>();

			services.AddAuthorization();
			services.AddAuthentication();
			services.AddControllersWithViews();
		}

		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
			}

			app.UseStatusCodePages();

			app.UseStaticFiles();
			app.UseSession();

			app.UseRouting();
			
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseEndpoints(routes => {
				routes.MapControllerRoute(name: "Default", pattern: "{controller=Home}/{action=Index}");
				routes.MapControllerRoute(name: "Category", pattern: "/Catalog/Category/{par1?}/{par2?}/{par3?}");
			});
		}
	}
}
