using API.DependencyInjection;
using API.Models.Context;
using API.Models.Entities.Repositories.Entities;
using API.Models.Entities.Repositories.Interfaces;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1",
        new OpenApiInfo()
        {
            Title = "Swagger Demo API",
            Description = "Demo API for showing Swagger",
            Version = "v1"
        });
});

builder.Services.AddPersistence(builder.Configuration);

#region Repositories
builder.Services.AddTransient<IDivisionRepository, DivisionRepository>();
builder.Services.AddTransient<IGroupRepository, GroupRepository>();
builder.Services.AddTransient<IParentRepository, ParentRepository>();
builder.Services.AddTransient<IRoleRepository, RoleRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
#endregion

builder.Services.AddDataProtection().PersistKeysToDbContext<CuratorMagazineContext>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        var context = serviceProvider.GetRequiredService<CuratorMagazineContext>();
    }
    catch (Exception)
    {
        Console.WriteLine("");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo API");
    });
}

app.UseAuthentication();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
