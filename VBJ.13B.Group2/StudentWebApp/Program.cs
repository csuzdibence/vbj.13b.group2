using Students.Model;
using Students.Model.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();



builder.Services.AddDistributedMemoryCache(); // For in-memory session storage
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Set session timeout
    options.Cookie.HttpOnly = true;                // Prevent client-side access to the cookie
    options.Cookie.IsEssential = true;             // Ensure the cookie is sent even if tracking is disabled
});





// IoC container - C#-ban beépített - Inversion of Control
// Ez regisztrálja az IStudentManager interface-hez az InMemoryStudentManagert
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IStudentManager, DatabaseStudentManager>();
builder.Services.AddScoped<ITeacherManager, TeacherManager>();
builder.Services.AddScoped<IPasswordService, PasswordService>();
builder.Services.AddScoped<ILogin, TeacherLoginService>();
builder.Services.AddDbContext<StudentDbContext>();
builder.Services.AddSingleton<IStudentValidator, EmailDomainValidator>();











var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
