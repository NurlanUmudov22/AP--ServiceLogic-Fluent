using API_Intro.Data;
using API_Intro.DTOs.Sliders;
using API_Intro.Helpers;
using API_Intro.Injections;
using API_Intro.Services;
using API_Intro.Services.Interfaces;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
});


builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));


//builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly); //////

//builder.Services.AddScoped<ISliderService, SliderService>();



builder.Services.AddServices();




builder.Services.AddFluentValidationAutoValidation(config =>
{
    config.DisableDataAnnotationsValidation = true;
});


builder.Services.AddScoped<IValidator<SliderCreateDto>, SliderCreateDtoValidator>();




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
