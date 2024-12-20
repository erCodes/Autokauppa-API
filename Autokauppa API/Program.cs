using Autokauppa_DAL;
using Autokauppa_DAL.CarRepository;
using Autokauppa_DAL.SellerRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<Autokauppa_DAL.CarRepository.IGet, Autokauppa_DAL.CarRepository.Get>();
builder.Services.AddScoped<Autokauppa_DAL.CarRepository.IPost, Autokauppa_DAL.CarRepository.Post>();
builder.Services.AddScoped<Autokauppa_DAL.CarRepository.IDelete, Autokauppa_DAL.CarRepository.Delete>();
builder.Services.AddScoped<Autokauppa_DAL.SellerRepository.IGet, Autokauppa_DAL.SellerRepository.Get>();
builder.Services.AddScoped<Autokauppa_DAL.SellerRepository.IPost, Autokauppa_DAL.SellerRepository.Post>();
builder.Services.AddScoped<Autokauppa_DAL.SellerRepository.IDelete, Autokauppa_DAL.SellerRepository.Delete>();
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
