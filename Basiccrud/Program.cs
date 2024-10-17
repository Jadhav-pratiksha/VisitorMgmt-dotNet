using Basiccrud.Common;
using Basiccrud.CosmosDb;
using Basiccrud.IServices;
using Basiccrud.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Dependencies
builder.Services.AddScoped<ICosmosDbServices, CosmosDbSevices>();
builder.Services.AddScoped<IVisitorServices, VisitorServices>();
builder.Services.AddScoped<IAdminServices, AdminServices>();
builder.Services.AddAutoMapper(typeof(AutoMappingProfile));

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
