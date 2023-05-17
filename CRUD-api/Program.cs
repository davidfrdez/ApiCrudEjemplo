using CRUD_api.Clases;
using CRUD_api.Models.Local;
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
builder.Services.AddCors();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapGet("/datos", () =>
{
    Dao dav = new Dao();
    return dav.trearDatos();
});

app.MapPost("/insertar",(Producto proc)=>
{
    Dao dao = new Dao();
    return dao.insertar(proc);
});

app.MapPost("/eliminar", (Producto id) =>
{
    Dao dao = new Dao();
    return dao.eliminar(id);
});

app.MapPost("/actualizar", (Producto id) =>
{
    Dao dao = new Dao();
    return dao.actualizar(id);
});



app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyMethod();
    c.AllowAnyOrigin();
});

app.Run();
