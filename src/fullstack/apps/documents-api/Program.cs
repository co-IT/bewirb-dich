using Fullstack.DocumentsApi.Features.Documents;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DocumentDbContext>(options => options.UseInMemoryDatabase("FullStack"));

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
  options.AddDefaultPolicy(
    policy =>
    {
      policy.WithOrigins("http://localhost:4200");
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

SeedInMemoryDatabase(app);

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();

void SeedInMemoryDatabase(IHost host)
{
  using var scope = host.Services.CreateScope();
  using var context = scope.ServiceProvider.GetService<DocumentDbContext>();

  if (context is null)
    return;

  context.Database.EnsureCreated();
}
