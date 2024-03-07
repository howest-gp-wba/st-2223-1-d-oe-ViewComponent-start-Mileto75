var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
   name: "DirectorMovies",
   pattern: "Director/{id}/Movies",
   defaults: new { Controller = "People", Action = "ShowDirectorMovies" });
app.MapControllerRoute(
   name: "Directors",
   pattern: "Directors",
   defaults: new { Controller = "People", Action = "ShowDirectors" });
app.MapControllerRoute(
   name: "MovieInfo",
   pattern: "Movies/{movieId}",
   defaults: new { Controller = "Movies", Action = "ShowMovie" });
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
