using Microsoft.AspNetCore.Diagnostics;
using TodoApi.AppDataContext;
using TodoApi.Models;
using TodoApi.Services;
using TodoAPI.Interface;
using TodoAPI.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbSettings>(builder.Configuration.GetSection("DbSettings"));
builder.Services.AddSingleton<TodoDbContext>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddLogging();
builder.Services.AddScoped<ITodoServices, TodoServices>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseExceptionHandler(appBuilder =>
{
    appBuilder.Run(async context =>
    {
        var exceptionHandler = context.RequestServices.GetRequiredService<GlobalExceptionHandler>();
        await exceptionHandler.TryHandleAsync(context, context.Features.Get<IExceptionHandlerFeature>().Error, context.RequestAborted);
    });
});
app.UseAuthorization();

app.MapControllers();

app.Run();