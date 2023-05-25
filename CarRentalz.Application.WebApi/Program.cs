using CarRentalz.Datas.Repository.Contract;
using CarRentalz.Datas.Repository;
using CarRentalz.Application.IoC;
using Newtonsoft.Json;


var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.Objects;
    options.SerializerSettings.Formatting = Formatting.Indented;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.ConfigureDBContext(configuration);

//Dependency Injection
builder.Services.ConfigureInjectionDependencyRepository();

builder.Services.ConfigureInjectionDependencyService();


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
