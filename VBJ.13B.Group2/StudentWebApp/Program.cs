using Students.Model;
using Students.Model.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Session regisztr�ci�
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.IsEssential = true;
    options.Cookie.HttpOnly = true;
});

// IoC container - C#-ban be�p�tett - Inversion of Control
// Ez regisztr�lja az IStudentManager interface-hez az InMemoryStudentManagert
builder.Services.AddScoped<IStudentManager, DatabaseStudentManager>();
builder.Services.AddScoped<ITeacherManager, DatabaseTeacherManager>();

builder.Services.AddScoped<IEncryptionService, SHA256EncryptionService>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationServiceWithSession>();


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
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
