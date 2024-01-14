using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProiectMedii.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy =>
   policy.RequireRole("Admin"));
});


// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Rezervari");
    options.Conventions.AuthorizeFolder("/Adrese");
    options.Conventions.AuthorizeFolder("/Membrii");
    options.Conventions.AuthorizeFolder("/Recenzii");
    options.Conventions.AuthorizeFolder("/Restaurante");
    options.Conventions.AllowAnonymousToPage("/Restaurante/Index");
    options.Conventions.AllowAnonymousToPage("/Restaurante/Details");
    options.Conventions.AllowAnonymousToPage("/Recenzii/Index");
    options.Conventions.AllowAnonymousToPage("/Recenzii/Details");
    options.Conventions.AuthorizeFolder("/Membrii", "AdminPolicy");
    options.Conventions.AuthorizeFolder("/Adrese", "AdminPolicy");

});
builder.Services.AddDbContext<ProiectMediiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectMediiContext") ?? throw new InvalidOperationException("Connection string 'ProiectMediiContext' not found.")));

builder.Services.AddDbContext<LibraryIdentityContext>(options =>

options.UseSqlServer(builder.Configuration.GetConnectionString("ProiectMediiContext") ?? throw new InvalidOperationException("Connectionstring 'ProiectMediiContext' not found.")));
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()

 .AddEntityFrameworkStores<LibraryIdentityContext>(); var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapRazorPages();

app.Run();
