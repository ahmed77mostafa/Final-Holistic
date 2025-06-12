using Ahmed_Mostafa_Saleh_3025305.Data;
using Ahmed_Mostafa_Saleh_3025305.Repositeries.Implementations;
using Ahmed_Mostafa_Saleh_3025305.Repositeries.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration.GetConnectionString("MyConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration));

builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();
builder.Services.AddScoped<IBranchRepo, BranchRepo>();

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
