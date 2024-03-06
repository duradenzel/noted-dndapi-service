var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var  allowedOrigins = "_allowedOrigins";
// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowedOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5065",
                                              "http://localhost:5173",
                                              "http://localhost:5010");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

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
