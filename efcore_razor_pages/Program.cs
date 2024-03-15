
using ef_models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SchoolContext>(options =>
{
    options.UseSqlServer(
        "Server=192.168.1.90;Database=SchoolDb;User ID=sa;Password=Random-123;TrustServerCertificate=true;"
     )
    .LogTo(sql => Console.WriteLine(sql),LogLevel.Information);
});

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
