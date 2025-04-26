using Microsoft.EntityFrameworkCore;
using skillhub.Models;
using skillhub.RepositeryLayer;
using skillhub.ServiceLayer;
using skillhub.ServiceLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<UserContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

builder.Services.AddControllers();

#region Dependency Injection
builder.Services.AddScoped<UserInterfaceSL, UserSL>();
builder.Services.AddScoped<UserInterfaceRL, UserRL>();
#endregion

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();



    app.UseCors("AllowAll"); // Allow all origins for development

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
