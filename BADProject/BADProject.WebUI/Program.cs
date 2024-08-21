using BADProject.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using SportStore.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using BADProject.Application.Services.Interfaces;
using BADProject.Infrastructure.Repositories;
using BADProject.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


string connString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connString));

builder.Services.AddDefaultIdentity<ApplicationUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IAnimeService, AnimeService>();
builder.Services.AddScoped<IAnimeRepo, AnimeRepo>();
builder.Services.AddScoped<IFileUploadService, FileUploadService>();
builder.Services.AddScoped<IAnimeListRepo, AnimeListRepo>();
builder.Services.AddScoped<IAnimeListService, AnimeListService>();



builder.Services.AddAuthorization(options => {
    options.AddPolicy("CanManageCatalog", policyBuilder => policyBuilder.RequireClaim("CanManageCatalog", "true"));
    options.AddPolicy("CanEditAnime", policy => policy.RequireClaim("Permission", "EditAnime"));
    options.AddPolicy("CanDeleteAnime", policy => policy.RequireClaim("Permission", "DeleteAnime"));
});


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();




var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=AnimeList}/{action=AnimeList}");

app.MapRazorPages();

app.Run();
