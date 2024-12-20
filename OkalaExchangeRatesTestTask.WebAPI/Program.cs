using OkalaExchangeRatesTestTask.Application.Services;
using OkalaExchangeRatesTestTask.Application.Settings;
using OkalaExchangeRatesTestTask.Domain.Contracts;
using OkalaExchangeRatesTestTask.WebAPI.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CryptoApiSettings>(builder.Configuration.GetSection("CryptoAPI"));
builder.Services.Configure<CurrencyApiSettings>(builder.Configuration.GetSection("CurrencyAPI"));

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddHttpClient();
builder.Services.AddScoped<ICryptoApiService, CryptoApiService>();
builder.Services.AddScoped<ICurrencyApiService, CurrencyApiService>();
builder.Services.AddScoped<ICurrencyService, CurrencyService>();

builder.Services.AddLogging(logging => logging.AddConsole());

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();

app.Run();
