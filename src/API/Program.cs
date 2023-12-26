using BuildingBlocks.Web;
using BuildingBlocks.MediatR;
using Customers;
using Figgle;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

var appOptions = builder.Configuration.GetSection("AppOptions").Get<AppOptions>();
Console.WriteLine(FiggleFonts.Standard.Render(appOptions.Name));

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.UseNamespaceRouteToken();
});

builder.Services.AddCustomMediatR(
    typeof(CustomerRoot).Assembly
);
builder.Services.AddHttpContextAccessor();
builder.Services.AddCustomerModules(builder.Configuration);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.UseApiEndpoints();
});
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressInferBindingSourcesForParameters = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    _ = endpoints.MapControllers();
});


app.Run();