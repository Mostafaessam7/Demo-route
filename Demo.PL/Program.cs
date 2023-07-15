using Demo.BLL.Interface;
using Demo.BLL.Mapper;
using Demo.BLL.Repository;
using Demo.DAL.Database;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddControllersWithViews()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization()
    .AddNewtonsoftJson(opt =>
    {
        opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });

builder.Services.AddDbContextPool<ProjectDbContext>(opts =>
       opts.UseSqlServer(builder.Configuration.GetConnectionString("DemoConnection")));


builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
{

    // Default Password settings.
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    options.Password.RequiredUniqueChars = 0;
}).AddEntityFrameworkStores<ProjectDbContext>()
.AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>(TokenOptions.DefaultProvider);


builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

builder.Services.AddScoped<IDepartmentRep, DepartmentRep>();
builder.Services.AddScoped<IEmployeeRep, EmployeeRep>();
builder.Services.AddScoped<ICountryRep, CountryRep>();
builder.Services.AddScoped<ICityRep, CityRep>();
builder.Services.AddScoped<IDistrictRep, DistrictRep>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


var supportedCultures = new[] {
      new CultureInfo("ar-EG"),
      new CultureInfo("en-US"),
};

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
});

app.UseStaticFiles();

app.UseRouting(); 

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
