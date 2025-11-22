using InsightFlow.Documents.Api.Application.Interfaces;
using InsightFlow.Documents.Api.Application.Services;
using InsightFlow.Documents.Api.Domain.Interfaces;
using InsightFlow.Documents.Api.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  
              .AllowAnyMethod()  
              .AllowAnyHeader(); 
    });
}); 

builder.Services.AddControllers();

builder.Services.AddSingleton<InMemoryDataContext>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var app = builder.Build();

app.UseCors("AllowAll");
app.UseMiddleware<InsightFlow.Documents.Api.Core.Middlewares.ErrorHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
