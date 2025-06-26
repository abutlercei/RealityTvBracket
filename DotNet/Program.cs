using DotNet.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "react-app/dist";
});

// Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

// Register Database Context

builder.Services.AddDbContext<SamplePoolDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register DataRepository service for database interactions
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPoolRepository, PoolRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();
if (!app.Environment.IsDevelopment())
{
    app.UseSpaStaticFiles();
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.UseCors();

// Map API Controllers
app.MapControllers();

app.MapWhen(context => !context.Request.Path.StartsWithSegments("/api"), spa =>
{
    spa.UseSpa(spaBuilder =>
    {
        spaBuilder.Options.SourcePath = "react-app";

        if (app.Environment.IsDevelopment())
        {
            spaBuilder.UseProxyToSpaDevelopmentServer("http://localhost:5173");
        }
    });
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
