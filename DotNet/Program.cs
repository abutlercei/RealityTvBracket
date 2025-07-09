using DotNet.Models;
using DotNet.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configuring AutoMapper Service
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));

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

// Register repositories for database interactions
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPoolRepository, PoolRepository>();

// Register services to call repositories
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IPoolService, PoolService>();

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

// using DotNet.Models;
// using DotNet.Services;
// using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllers();

// // Add CORS policy
// builder.Services.AddCors(options =>
// {
//     options.AddPolicy("AllowFrontend", builder =>
//     {
//         builder.WithOrigins("https://localhost:7125", "http://localhost:5173")
//             .AllowAnyMethod().AllowAnyHeader();
//     });
// });

// // Configuring AutoMapper Service
// builder.Services.AddAutoMapper(typeof(Program));
// builder.Services.AddAutoMapper(typeof(MappingProfile));

// // Register Database Context
// builder.Services.AddDbContext<SamplePoolDBContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// // Register repositories for database interactions
// builder.Services.AddScoped<IUserRepository, UserRepository>();
// builder.Services.AddScoped<IPoolRepository, PoolRepository>();

// // Register services to call repositories
// builder.Services.AddScoped<IUserProfileService, UserProfileService>();
// builder.Services.AddScoped<IPoolService, PoolService>();

// var app = builder.Build();

// // Middleware: Configure the HTTP request pipeline.
// app.UseHttpsRedirection();
// if (app.Environment.IsDevelopment())
// {
//     app.UseDeveloperExceptionPage();
// }
// else
// {
//     app.UseExceptionHandler("/Home/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseRouting();
// app.UseCors("AllowFrontend");
// app.UseAuthorization();

// // Map API Controllers
// app.MapControllers();

// app.UseSpa(spa =>
// {
//     spa.Options.SourcePath = "react-app";
//     spa.UseProxyToSpaDevelopmentServer("http://localhost:5173");
// });

// app.Run();
