using ResumeBuilder.Models.DataLayer;
using ResumeBuilder.Models.Repository;
using ResumeBuilder.Models.Repository.IRepository;
using ResumeBuilder.Utility;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ResumeBuilder.CvLogic;

namespace ResumeBuilder
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddDbContext<ResumeBuilderContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("ResumeBuilderContext")));

            //services.AddIdentity<IdentityUser, IdentityRole>().AddDefaultTokenProviders()
            //   .AddEntityFrameworkStores<ResumeBuilderContext>();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
	            .AddRoles<IdentityRole>()
	            .AddEntityFrameworkStores<ResumeBuilderContext>();

			services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddRazorPages();


            var env = services.FirstOrDefault(s => typeof(IWebHostEnvironment).IsEquivalentTo(s.ServiceType));

            

            services.AddSingleton(new HtmlToPdfConverter());

            var templatesPath = Path.Combine((env.ImplementationInstance as IWebHostEnvironment).ContentRootPath, "CvTemplates");
            var templates = InitializeTemplates(templatesPath, Configuration.GetValue<int>("TemplatesRefreshRate"));
            services.AddSingleton(templates);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

          
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{Area=Customer}/{controller=Home}/{action=Index}/{id?}");
            });


        }

        private Dictionary<string, Template> InitializeTemplates(string templatesPath, int refreshCacheSeconds)
        {
            var templates = new Dictionary<string, Template>();
            foreach (var folder in Directory.GetDirectories(templatesPath))
            {
                if (File.Exists(Path.Combine(folder, Template.HTML_FILE_NAME)))
                {
                    var template = new Template(folder, refreshCacheSeconds);
                    templates.Add(template.Name, template);
                }
            }
            return templates;
        }
    }
}
