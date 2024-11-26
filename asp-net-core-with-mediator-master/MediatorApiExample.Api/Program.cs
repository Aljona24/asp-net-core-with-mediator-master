using System;
using MediatorApiExample.Api.Middleware;
using MediatorApiExample.Application;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
    .AddNewtonsoftJson();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApplication(s=>
{
    builder.Configuration.Bind(s);
});

builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed(isOriginAllowed: _ => true)
        .AllowCredentials()));

builder.Services.AddHttpContextAccessor();

builder.Services.AddSwaggerGen(s =>
{
    s.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    s.CustomSchemaIds(x => x.FullName);
});

//builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining(typeof(GetFriendListQuery)));

/*builder.Services.AddMediatR(configuration =>
{
    configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
});*/
//builder.Services.AddMediatR(Assembly.GetExecutingAssembly());
builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
var app = builder.Build();

// Налаштовуємо middleware
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
// app.UseMiddleware<LoggingMiddleware>();
app.UseCors("CorsPolicy");
app.UseRouting();        
app.UseMiddleware<ValidationExceptionHandlingMiddleware>();
app.UseAuthorization();
app.MapControllers();
//app.UseEndpoints(endpoints =>
//{
 //   endpoints.MapControllers();
//});
app.MapDefaultControllerRoute();

app.UseSwagger();
app.UseSwaggerUI(s => { s.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

// Запускаємо програму
app.Run();

