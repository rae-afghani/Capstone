var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews().AddNewtonsoftJson();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddMemoryCache();
builder.Services.AddSession();

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
    pattern: "Admin/{controller=Book}/{action=Index}/{id?}");


//paging, sorting, filtering
app.MapControllerRoute(
    name: "",
    pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}/filter/{author}/{genre}/{price}"
    );
//paging and sorting
app.MapControllerRoute(
    name: "",
    pattern: "{controller}/{action}/page/{pagenumber}/size/{pagesize}/sort/{sortfield}/{sortdirection}"
    );


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
