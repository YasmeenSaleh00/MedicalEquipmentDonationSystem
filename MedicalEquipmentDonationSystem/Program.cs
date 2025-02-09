using MedicalEquipmentDonationSystem.Context;
using MedicalEquipmentDonationSystem.Implementations;
using MedicalEquipmentDonationSystem.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Hope in Hands API",
        Version = "first version",
        Description = " API For enables users to easily share and exchange medical equipment. " +
        "It allows donors to list their equipment and seekers to submit requests for needed devices.",
        Contact = new OpenApiContact
        {
            Name = "Yasmeen Saleh",
            Email = "yasmeensaleh147@gmail.com",
            Url = new Uri("https://www.linkedin.com/in/yasmeen-saleh-0a9968257/")

        }
    });
    //enabling xml comments
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}); 
builder.Services.AddDbContext<MEDSDbContext>(con => con.UseSqlServer("Data Source=DESKTOP-40R4L6L\\SQLEXPRESS;Initial Catalog=MEDSDb;Integrated Security=True;Trust Server Certificate=True"));
//Services

builder.Services.AddScoped<IAuthanticationService,AuthanticationService>();
builder.Services.AddScoped<ILookupService, LookupService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IProductService , ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();  
builder.Services.AddScoped<ITransactionService, TransactionService>();  
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
//builder.Services.AddScoped<IHttpContextAccessor,HttpContextAccessor>();

//Configure Serilog 
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
//string loggerPath = configuration.GetSection("LoggerPath").Value;
Serilog.Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).
                WriteTo.File(Path.Combine(Directory.GetCurrentDirectory(), "Logs/MELogging.txt"), rollingInterval: RollingInterval.Day).
                CreateLogger();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});


var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//configure files 
app.UseStaticFiles();
// Add custom static files middleware
var imagesDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Images");
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesDirectory),
    RequestPath = "/Images"
});

app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();

// Start the application
try
{
    Log.Information("Start Running The API");
    Log.Information("App Runs Successfully");
    app.Run();

}
catch (Exception ex)
{
    Log.Information("An Error Occurred");
    Log.Error($"Error {ex.Message} was Prevent Application from run successfully");
}

