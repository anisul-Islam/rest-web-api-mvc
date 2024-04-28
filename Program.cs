var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();



// User - UserId, Name, Email, Password, Address, Image, IsAdmin, IsBanned, CreatedAt

// Products, Categories, Orders

// dotnet add package Microsoft.AspNetCore.OData --version 8.0.0-preview3
// dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 6.0.0-preview.6.21355.2
// dotnet add package Swashbuckle.AspNetCore --version 6.2.3


// Categories 
// model -> service -> controller