using AutoMapper;
using Service.Repositories;
using WebApp.Service.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IEnderecoRepository, EnderecoRepository>();
builder.Services.AddHttpClient<IEnderecoRepository,EnderecoRepository>(
    c => c.BaseAddress = new Uri(builder.Configuration["ServiceURL:ProductAPI"])
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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