using Microsoft.EntityFrameworkCore;
using ToDoListWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";

// Add services to the container.
builder.Services.AddRazorPages();

// Register the database context
builder.Services.AddDbContext<ToDoContext>(options =>
    options.UseInMemoryDatabase("TodoList")); // Using an in-memory database

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();


app.Urls.Add($"http://0.0.0.0:{port}");


app.Run();
