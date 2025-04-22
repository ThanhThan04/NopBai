using LeThanhThan_K2023_ThiGk.Data;
using LeThanhThan_K2023_ThiGk.Services.Course;
using LeThanhThan_K2023_ThiGk.Services.Enrollment;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Đăng ký DbContext với SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//tao 1 scope de chay 
builder.Services.AddScoped<ICourseService,CourseSevice>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();


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
