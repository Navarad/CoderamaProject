using CoderamaProject.Services;
using CoderamaProject.Services.Formatters;
using CoderamaProject.Services.Storages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IDocumentService, InMemoryDocumentService>();
builder.Services.AddSingleton<IDocumentFormatterFactory, DocumentFormatterFactory>();
builder.Services.AddSingleton<JsonDocumentFormatter>();
builder.Services.AddSingleton<XmlDocumentFormatter>();

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
