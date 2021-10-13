using EZOffertes.Server.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Blazor;
using EZOffertes.Server.Data;
using System.Net.Http;
using System.Net.Http.Headers;
using EZOffertes.Server.Shared;

namespace EZOffertes.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //string ApiServiceBaseURL = "https://localhost:44301/";
            string ApiServiceBaseURL = Configuration["ApiServiceUrl"];
            AuthConfig authConfig = new (Configuration);
            string bearerToken = authConfig.GetBearerToken();

            services.AddAuthentication("Identity.Application")
                .AddCookie();
            services.AddRazorPages();
            services.AddServerSideBlazor();
            services.AddSingleton(Configuration);
            services.AddHttpClient<IEmployeeService, ApiEmployeeService>(c => { 
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddHttpClient<IRelationService, ApiRelationService>(c => {
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddHttpClient<IOrderService, ApiOrderService>(c => {
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddHttpClient<IOrderDetailService, ApiOrderDetailService>(c => {
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddHttpClient<IUnitOfMeasureService, ApiUnitOfMeasureService>(c => {
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddHttpClient<IShippingMethodService, ApiShippingMethodService>(c => {
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddHttpClient<IQuickProductSetService, ApiQuickProductSetService>(c => {
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddHttpClient<IProductService, ApiProductService>(c => {
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddHttpClient<IProductCategoryService, ApiProductCategoryService>(c => {
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddHttpClient<IPersonTitleService, ApiPersonTitleService>(c => {
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddHttpClient<IInvoiceService, ApiInvoiceService>(c => {
                c.BaseAddress = new Uri(ApiServiceBaseURL);
                c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);
            });
            services.AddSyncfusionBlazor();
            services.AddScoped<ErrorInfo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(Configuration.GetSection("Syncfusion")["LicenseKey"] );
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
