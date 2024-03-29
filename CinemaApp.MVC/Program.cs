using CinemaApp.MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// appsettings.json kullanýmý için:

var settings = builder.Configuration.GetSection("AppSettings").Get<AppSettings>();

builder.Services.AddHttpClient(); // Client nesnesine api'ye json formatýnda istek atmak için ihtiyacým var.

builder.Services.AddSingleton(settings);


// addSingleton -> Yukarýdaki AppSettings class'ýný newlenip oluþturduðu nesneden tek bir kopya olacak ve hep ayný kopya (instance) kullanýlacak.

// addScoped -> Her istek yeni kopya.

// burada neden AddSingleton kullanýyoruz da AddScoped kullanmýyoruz? Bu önemli bir konu.

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
    pattern: "{controller=Movie}/{action=Index}/{id?}");

app.Run();
