var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



builder.Services.AddCors(options =>
{
    options.AddPolicy("Access-Control-Allow-Origin",
                    builder =>
                    {
                        builder.WithOrigins("*")
                           .AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    });

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("Access-Control-Allow-Origin");

//app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
