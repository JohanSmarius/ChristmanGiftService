using HotChocolate;
using Microsoft.EntityFrameworkCore;
using SantaTest.Data;
using SantaTest.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPooledDbContextFactory<GiftContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("SantaContext")).EnableSensitiveDataLogging()).
    AddLogging(Console.WriteLine);

builder.Services.AddGraphQLServer().AddQueryType<FamilyQuery>().RegisterDbContext<GiftContext>(DbContextKind.Pooled).
    AddProjections().AddFiltering().AddMutationType<FamilyMutation>().RegisterDbContext<GiftContext>(DbContextKind.Pooled);

builder.Services.AddControllers();
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

app.MapGraphQL();

app.Run();
