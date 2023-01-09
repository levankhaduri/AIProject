using AIProject.Services.Implementations;
using AIProject.Services.Interfaces;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ISearchService, SearchService>();

builder.Services.AddHttpClient("OpenAI", httpClient => 
{
    httpClient.BaseAddress = new Uri("https://api.openai.com/v1/images/generations");



    httpClient.DefaultRequestHeaders.Add(
        HeaderNames.Authorization, "Bearer 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");
});

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
