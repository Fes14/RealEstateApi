using Api.Sevices;
using BusinessLogic.DeveloperService;
using BusinessLogic.RealEstateService;
using BusinessLogic.RealEstateTypeService;
using DataBase.Db;
using DataBase.Db.Common.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo() { Title = "Api", Version = "v1" });
    c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "Annotation.xml"));
});


builder.Services.AddScoped<IRealEstateService, RealEstateService>();
builder.Services.AddScoped<IDeveloperService, DeveloperService>();
builder.Services.AddScoped<IRealEstateTypeService, RealEstateTypeService>();
builder.Services.AddScoped<IRealStateMapper, ObjectMapper>();

var compileConfiguration = new CompileConfiguration();

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(compileConfiguration.GetConfiguration(), optional: true, reloadOnChange: true);

builder.Services.AddSingleton(builder.Configuration.GetSection("ConnectionSettings").Get<ConnectionSettings>());

builder.Services.AddScoped<ICompanyDataBase, CompanyDataBase>();
builder.Services.AddCors(options =>
      {
          options.AddPolicy("AllowSpecificOrigin",
              builder => builder
                  .WithOrigins("http://localhost:4200")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials());
      });
var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}


//app.UseHttpsRedirection();


app.UseCors("AllowSpecificOrigin");


app.UseAuthorization();

app.MapControllers();

app.Run();
