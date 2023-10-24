using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;
builder.Services.AddMvcCore()
    .AddApiExplorer()
    .AddCors();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x.AllowAnyOrigin());
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();





