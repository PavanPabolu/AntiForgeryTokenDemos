using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllersWithViews(options =>
{
    //To enable the antiforgery token validation globally.
    //To use the AutoValidateAntiforgeryTokenAttribute to automatically validate the antiforgery token for all non-GET, HEAD, OPTIONS, and TRACE HTTP methods. This ensures that all POST, PUT, PATCH, and DELETE requests are protected by default, without the need to manually add the ValidateAntiForgeryToken attribute to each action method.
    //options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});
builder.Services.AddAntiforgery();


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

//To add the antiforgery middleware to the request pipeline, which will automatically validate the antiforgery token for all non-GET, HEAD, OPTIONS, and TRACE HTTP methods.
app.UseAntiforgery();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
