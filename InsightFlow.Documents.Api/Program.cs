using InsightFlow.Documents.Api.Application.Interfaces;
using InsightFlow.Documents.Api.Application.Services;
using InsightFlow.Documents.Api.Domain.Interfaces;
using InsightFlow.Documents.Api.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddSingleton<InMemoryDataContext>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();



app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
