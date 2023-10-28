using ExtratoContaCorrenteApi.Context;
using ExtratoContaCorrenteApi.Repository.LancamentoRepo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ContextDb>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ILancamentoRepository, LancamentoRepository>();

var app = builder.Build();
builder.Services.AddCors();
app.UseCors(opt =>
{
	opt.AllowAnyHeader();
	opt.AllowAnyMethod();
	opt.AllowAnyOrigin();
});

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
