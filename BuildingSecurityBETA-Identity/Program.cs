using BuildingSecurityBETA_Identity;
using BuildingSecurityBETA_Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var assembly = typeof(Program).Assembly.GetName().Name;
var defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<BuildingIdentityContext>(options =>
                        options.UseSqlServer(defaultConnection, b => b.MigrationsAssembly(assembly)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<BuildingIdentityContext>();

//add-migration InitIdenitytContext -Context BuildingIdentityContext
//update-database -Context BuildingidentyContext

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(defaultConnection, opt => opt.MigrationsAssembly(assembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(defaultConnection, opt => opt.MigrationsAssembly(assembly));
    })
    .AddDeveloperSigningCredential();

//add-migration InitPers -c PersistedGrantDbContext   ---  update-database -Context PersistedGrantDbContext
//add-migration InitConfig -c ConfigurationDbContext  ---   update-database -Context ConfigurationDbContext

//Seeding.SeedDatabase(host);

var app = builder.Build();

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

app.UseIdentityServer();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
