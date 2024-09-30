using UTC_ASP.NET_Web_Lab.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configure DbContext for SchoolContext
builder.Services.AddDbContext<SchoolContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolContext"))
);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages(); // Add Razor Pages services

//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();

//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

// Initialize the database
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    DbInitializer.Initialize(services);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map controllers and Razor Pages
app.UseEndpoints(endpoints =>
{
    // Student
    _ = endpoints.MapControllerRoute(
        name: "student_index",
        pattern: "Admin/Students/List",
        defaults: new { controller = "Student", action = "Index" }
    );
    _ = endpoints.MapControllerRoute(
        name: "student_create",
        pattern: "Admin/Students/Add",
        defaults: new { controller = "Student", action = "Create" }
    );

    // Learner
    _ = endpoints.MapControllerRoute(
        name: "learner_index",
        pattern: "Admin/Learners/List",
        defaults: new { controller = "Learner", action = "Index" }
    );
    _ = endpoints.MapControllerRoute(
        name: "learner_by_id",
        pattern: "Admin/Learners/LearnerByMajorID/{id?}",
        defaults: new { controller = "Learner", action = "LearnerByMajorID" }
    );

    // Course
    _ = endpoints.MapControllerRoute(
        name: "course_index",
        pattern: "Admin/Courses/List",
        defaults: new { controller = "Course", action = "Index" }
    );

    // Home
    _ = endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}"
    );
});
app.MapRazorPages();

app.Run();
