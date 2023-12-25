using BuildingBlocks.Web;
using Figgle;
var builder = WebApplication.CreateBuilder(args);

var appOptions = builder.Configuration.GetSection("AppOptions").Get<AppOptions>();
Console.WriteLine(FiggleFonts.Standard.Render(appOptions.Name));

// Add services to the container.
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

app.Run();