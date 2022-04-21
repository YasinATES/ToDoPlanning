using ToDoPlanning.Business.Abstract;
using ToDoPlanning.Business.Concrete;
using ToDoPlanning.DataAccess;
using ToDoPlanning.DataAccess.Abstract;
using ToDoPlanning.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddTransient<IWorkTaskRepository, WorkTaskDal>();
builder.Services.AddTransient<IWorkTaskBusiness, WorkTaskBusiness>();

var app = builder.Build();

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
