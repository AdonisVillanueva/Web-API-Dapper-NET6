using IssuerIssuerApi.Repository;
using HealthInsuranceCaseworkApi.Context;
using HealthInsuranceCaseworkApi.Contracts;
using HealthInsuranceCaseworkApi.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IParentOrgRepository, ParentOrgRepository>();
builder.Services.AddScoped<IIssuerRepository, IssuerRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();
}



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
