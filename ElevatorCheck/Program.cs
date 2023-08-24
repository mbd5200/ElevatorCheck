using ElevatorCheckAPI.Api.Middleware;
using ElevatorCheckAPI.Business.Abstract;
using ElevatorCheckAPI.DAL.Abstract.DataManagement;
using ElevatorCheckAPI.DAL.Concrete.EntityFramework.DataManagement;
using ElevatorCheckAPI.Helper.Globals;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using ElevatorCheckAPI.Api.Middleware;
using ElevatorCheckAPI.Business.Abstract;
using ElevatorCheckAPI.Business.Concrete;
using ElevatorCheckAPI.DAL.Abstract.DataManagement;
using ElevatorCheckAPI.DAL.Concrete.EntityFramework.Context;
using ElevatorCheckAPI.DAL.Concrete.EntityFramework.DataManagement;
using ElevatorCheckAPI.Helper.Globals;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null
);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDbContext<ElevatorContext>();
builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IStructureService, StructureManager>();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.Configure<JWTExceptURLList>(builder.Configuration.GetSection(nameof(JWTExceptURLList)));



var app = builder.Build();


app.UseGlobalExceptionMiddleware();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseApiAuthorizationMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();