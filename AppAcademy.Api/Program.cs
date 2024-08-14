using AppAcademy.Api.Middlewares;
using AppAcademy.Application.Dtos.GroupDtos;
using AppAcademy.Application.Profiles;
using AppAcademy.Application.Services.Implementations;
using AppAcademy.Application.Services.Interfaces;
using AppAcademy.Core.Entities;
using AppAcademy.Core.Repositories;
using AppAcademy.Data.Data;
using AppAcademy.Data.Implementations;
using FluentValidation;
using FluentValidation.AspNetCore;
using MicroElements.Swashbuckle.FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddControllers()
    .ConfigureApiBehaviorOptions(opt =>
    {
        opt.InvalidModelStateResponseFactory = context =>
        {
            var errors = context.ModelState.Where(e => e.Value?.Errors.Count > 0).ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.Errors.Select(e => e.ErrorMessage).ToArray()
                );

            var mssg = new
            {
                message = "an error occurred..",
                errors = errors
            };

            return new BadRequestObjectResult(mssg);
        };
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AcademyAppDbContext>(opt =>
{
    opt.UseSqlServer(config.GetConnectionString("DefaultConnection"));
});

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters()
.AddValidatorsFromAssemblyContaining<GroupCreateDto>()
.AddFluentValidationRulesToSwagger();

builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IGroupRepository, GroupRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfile(new MapperProfile(new HttpContextAccessor()));
});

var app = builder.Build();

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password = new()
    {
        RequiredLength = 8,
        RequireUppercase = true,
        RequireLowercase = true,
        RequireDigit = true,
        RequireNonAlphanumeric = true
    };
    options.Lockout = new()
    {
        MaxFailedAccessAttempts = 8,
        AllowedForNewUsers = true,
        DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3)
    };
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AcademyAppDbContext>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<ExceptionMiddlewear>();
app.UseAuthorization();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
