using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using EZOffertes.Api.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOffertes.Api
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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.Audience = Configuration.GetSection("AzureAd")["ResourceID"];
                    opt.Authority = $"{Configuration.GetSection("AzureAd")["Instance"]}{Configuration.GetSection("AzureAd")["TenantId"]}";
                });
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DBConnection")));
            services.AddScoped<IEmployeeRepository, SEmployeeRepository>();
            services.AddScoped<IInvoiceRepository, SInvoiceRepository>();
            services.AddScoped<IOrderDetailRepository, SOrderDetailRepository>();
            services.AddScoped<IOrderRepository, SOrderRepository>();
            services.AddScoped<IPaymentRepository, SPaymentRepository>();
            services.AddScoped<IPersonTitleRepository, SPersonTitleRepository>();
            services.AddScoped<IProductCategoryRepository, SProductCategoryRepository>();
            services.AddScoped<IProductPropertyRepository, SProductPropertyRepository>();
            services.AddScoped<IProductRepository, SProductRepository>();
            services.AddScoped<IQuickProductSetItemRepository, SQuickProductSetItemRepository>();
            services.AddScoped<IQuickProductSetRepository, SQuickProductSetRepository>();
            services.AddScoped<IRelationAddressRepository, SRelationAddressRepository>();
            services.AddScoped<IRelationNoteRepository, SRelationNoteRepository>();
            services.AddScoped<IRelationPhoneNumberRepository, SRelationPhoneNumberRepository>();
            services.AddScoped<IRelationRepository, SRelationRepository>();
            services.AddScoped<IShippingMethodRepository, SShippingMethodRepository>();
            services.AddScoped<IUnitOfMeasureRepository, SUnitOfMeasureRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EZOffertes.Api", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EZOffertes.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
