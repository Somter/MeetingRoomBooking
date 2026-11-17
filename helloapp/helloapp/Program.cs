using helloapp;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (ApplicationContext db = new ApplicationContext ())
{
    User Tom = new User{ Age = 12, Name = "Tom" };
    User Alice = new User { Age = 14, Name = "Alice" };

    db.Users.Add(Tom);
    db.Users.Add(Alice);
    db.SaveChanges();

    Console.WriteLine("Objects were created succsesfuly");

    foreach(var user in db.Users)
    {
        Console.WriteLine($"{user.Name} - {user.Age}");
    }


}

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
