using CuratorMagazineBlazorApp.Data.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddAntDesign();
builder.Services.AddCors();

#region Services
builder.Services.AddSingleton<UserService>();
builder.Services.AddSingleton<DivisionService>();
builder.Services.AddSingleton<GroupService>();
builder.Services.AddSingleton<ParentService>();
builder.Services.AddSingleton<RoleService>();
#endregion


builder.Services.AddHttpClient("CuratorMagazineWebAPI", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["APP_API"]);
    client.Timeout = TimeSpan.FromMinutes(15);
});

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
app.UseCors(builder => builder.AllowAnyOrigin());

app.MapBlazorHub();
app.MapFallbackToPage("/Index");

app.Run();
