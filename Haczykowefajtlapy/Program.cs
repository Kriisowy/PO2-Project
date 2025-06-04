using Haczykowefajtlapy.Components;
using Haczykowefajtlapy.Data;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

QuestPDF.Settings.License = LicenseType.Community;

var connStr = builder.Configuration.GetConnectionString("FishingClubDb");

builder.Services.AddDbContext<FishingClubContext>(options =>
    options.UseNpgsql(connStr));
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();


app.MapControllers();
app.Run();
