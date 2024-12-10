using Autokauppa_DAL;
using Autokauppa_DAL.CarRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGet, Get>();
builder.Services.AddScoped<IPost, Post>();
builder.Services.AddScoped<IDelete, Delete>();
builder.Services.AddSqlServer<Context>("Server=(localdb)\\mssqllocaldb;Database=AutokauppaDb;Trusted_Connection=true;MultipleActiveResultSets=true");

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
