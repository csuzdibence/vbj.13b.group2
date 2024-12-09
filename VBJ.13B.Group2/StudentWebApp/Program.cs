using Students.Model;
using Students.Model.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();









// IoC container - C#-ban beépített - Inversion of Control
// Ez regisztrálja az IStudentManager interface-hez az InMemoryStudentManagert
builder.Services.AddScoped<IStudentManager, DatabaseStudentManager>();
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
