using Infra.Ioc;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.BancoDados(builder.Configuration);
builder.Services.InjeicaoDeIdependenciaRepository(builder.Configuration);
builder.Services.InjeicaoDeIdependenciaServices(builder.Configuration);
builder.Services.AddAuth(builder.Configuration);

builder.Services.AddCors(options => {
    options.AddPolicy("AllowAngular", policy =>
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();
app.UseCors("AllowAngular");
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
