using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;
using ttcm_api.Contexts;
using ttcm_api.Interfaces;
using ttcm_api.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MainAppContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-C4QB4O5\\SQLEXPRESS;Database=ttcm;Trusted_Connection=True;TrustServerCertificate=True\r\n");
});



builder.Services.AddScoped<IProgramCRUD, ProgramsService>();
builder.Services.AddScoped<IEnrollmentCRUD, EnrollmentService>();

// Fix: Ensure CoursesService implements ICourseCRUD
builder.Services.AddScoped<ICourseCRUD, CoursesService>();

builder.Services.AddScoped<ITraineeService, TraineesService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
