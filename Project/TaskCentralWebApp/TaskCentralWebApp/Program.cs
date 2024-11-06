using Microsoft.EntityFrameworkCore;
using TaskCentralWebApp.Models;
using Microsoft.AspNetCore.Identity;
using TaskCentralWebApp.Areas.Identity.Data;
using TaskCentralWebApp.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(typeof(LogExceptionFilter));
});

builder.Services.AddDbContext<TaskCentralDBContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("ModelsConnection")
    ));

builder.Services.AddDbContext<IdentityContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("IdentityContextConnection")
    ));

builder.Services.AddDefaultIdentity<Users>()
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;
app.UseAuthorization();

app.MapControllerRoute(
    name: "projectmembers",
    pattern: "ProjectMembers/{action=Index}/{projectid?}/{userid?}",
    defaults: new { controller = "ProjectMembers", action = "Index" });

app.MapControllerRoute(
    name: "tasks",
    pattern: "Tasks/{action=Index}/{projectid?}",
    defaults: new { controller = "Tasks", action = "Index" });

app.MapControllerRoute(
    name: "comments",
    pattern: "Comments/{action=Index}/{taskid?}",
    defaults: new { controller = "Comments", action = "Index" });

app.MapControllerRoute(
    name: "documents",
    pattern: "Documents/{action=Index}/{taskid?}",
    defaults: new { controller = "Documents", action = "Index" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

using (var serviceScope = app.Services.CreateScope())
{
    IServiceProvider serviceProvider = serviceScope.ServiceProvider;
    await ContextSeed.SeedRolesAsync(serviceProvider);
    await ContextSeed.SeedAdminAsync(serviceProvider);
    await ContextSeed.SeedTestUsersAsync(serviceProvider);
}

app.Run();
