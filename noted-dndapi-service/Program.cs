using noted_dndapi_service.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var  allowedOrigins = "_allowedOrigins";
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5173","http://localhost:5170");
                      });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddScoped<DndApiService, DndApiService>();
builder.Services.AddScoped<DndApiRepository, DndApiRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(allowedOrigins);


app.UseAuthorization();

app.MapControllers();

app.Run();
