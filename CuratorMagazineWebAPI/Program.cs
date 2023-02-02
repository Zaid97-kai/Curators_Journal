// ***********************************************************************
// Assembly         : CuratorMagazineWebAPI
// Author           : Zaid
// Created          : 11-03-2022
//
// Last Modified By : Zaid
// Last Modified On : 12-25-2022
// ***********************************************************************
// <copyright file="Program.cs" company="CuratorMagazineWebAPI">
//     Zaid97-kai
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.AspNetCore.DataProtection;
using CuratorMagazineWebAPI.DependencyInjection;
using CuratorMagazineWebAPI.Models.Context;
using Microsoft.OpenApi.Models;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Entities;
using CuratorMagazineWebAPI.Models.Entities.Repositories.Interfaces;

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
