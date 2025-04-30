using apiCep.Interfaces;
using apiCep.Mappings;
using apiCep.Rest;
using apiCep.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEnderecoServices, EnderecoService>();
builder.Services.AddSingleton<IBancoServices, BancoService>();
builder.Services.AddSingleton<IBrasilApi, BrasilApiService>();
builder.Services.AddAutoMapper(typeof(EnderecoMappings));
builder.Services.AddAutoMapper(typeof(BancoMapping));

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
