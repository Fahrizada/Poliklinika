using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Poliklinika.Model;
using PoliklinikaApi.Helpers;
using PoliklinikaAPI.Data;
using PoliklinikaAPI.Helpers;
using PoliklinikaAPI.Interfaces;
using PoliklinikaAPI.Mappers;
using PoliklinikaAPI.Services;
using PoliklinikaAPI.ViewModels;
using AuthenticationService = PoliklinikaAPI.Services.AuthenticationService;

namespace PoliklinikaAPI
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
            services.AddCors();

            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Poliklinika API", Version = "v1" });
                c.AddSecurityDefinition("basic", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                          {
                              Reference = new OpenApiReference
                              {
                                  Type = ReferenceType.SecurityScheme,
                                  Id = "basic"
                              }
                          },
                          new string[] {}
                    }
                });
            });

            services.AddAuthentication("BasicAuthentication")
             .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            var connection = Configuration.GetConnectionString("cs1");
            services.AddDbContext<DBContext>(
            options => options.UseSqlServer(connection),
            ServiceLifetime.Transient);

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddScoped<UserBaseInterface<Korisnik, KorisnikVM, SignUpKorisnikVM>, UserBaseService<Korisnik, KorisnikVM, SignUpKorisnikVM>>();
            services.AddScoped<UserBaseInterface<Doktor, DoktorVM, CreateDoktorVM>, UserBaseService<Doktor, DoktorVM, CreateDoktorVM>>();
            services.AddScoped<UserBaseInterface<Tehnicar, TehnicarVM, CreateTehnicarVM>, UserBaseService<Tehnicar, TehnicarVM, CreateTehnicarVM>>();
            services.AddScoped<UserBaseInterface<Admin, Admin, SignupAdminVM>, UserBaseService<Admin, Admin, SignupAdminVM>>();
            services.AddScoped<UserBaseInterface<Osoblje, OsobljeVM, OsobljeVM>, UserBaseService<Osoblje, OsobljeVM, OsobljeVM>>();
            services.AddScoped<AuthenticationInterface, AuthenticationService>();
            services.AddScoped<BaseInterface<Osoblje, OsobljeVM>, OsobljeService>();
            services.AddScoped<BaseInterface<Nalaz, NalazVM>, NalazService>();
            services.AddScoped<BaseInterface<Odjel, OdjelVM>, BaseService<Odjel, OdjelVM>>();
            services.AddScoped<BaseInterface<Konsultacije, KonsultacijeVM>, BaseService<Konsultacije, KonsultacijeVM>>();
            services.AddScoped<BaseInterface<KonsultacijePoruka, KonsultacijePorukaVM>, BaseService<KonsultacijePoruka, KonsultacijePorukaVM>>();
            services.AddScoped<BaseInterface<Pregled, PregledVM>, PregledService>();
            services.AddScoped<BaseInterface<Uplata, UplataVM>, BaseService<Uplata, UplataVM>>();
            services.AddScoped<BaseInterface<Obaveza, ObavezaVM>, ObavezaServis>();
            services.AddScoped<BaseInterface<Izvjestaj, IzvjestajVM>, IzvjestajService>();
            services.AddScoped<BaseInterface<ChatObaveza, ChatObavezaVM>, BaseService<ChatObaveza, ChatObavezaVM>>();
            services.AddScoped<BaseInterface<ChatPoruka, ChatPorukaVM>, ChatService>();
            services.AddScoped<BaseInterface<Raspored, RasporedVM>, RasporedService>();


            services.AddIdentity<User, Role>()
                    .AddEntityFrameworkStores<DBContext>()
                    .AddDefaultTokenProviders();

            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
