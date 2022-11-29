using CapstoneV4.Models.DataLayer;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
string connString = builder.Configuration.GetConnectionString("CapstoneDB");

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddDbContext<CapstoneDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CapstoneDB")));

var app = builder.Build();


app.UseHsts();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.UseAuthorization();


app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Course}/{action=Index}/{id?}");


//paging, sorting, filtering courses
app.MapControllerRoute(
    name: "",
    pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}/filter/{program}/{topic}/{tuition}"
    );
//paging and sorting through system
app.MapControllerRoute(
    name: "",
    pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
