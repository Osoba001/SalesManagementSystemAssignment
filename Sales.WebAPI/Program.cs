using Sales.Library.DataAccess;
using Sales.Library.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IFluentNHibernateHelper>(x=>
new FluentNHibernateHelper(builder.Configuration.GetConnectionString("defaultConnection")));
builder.Services.AddTransient<IItemService,ItemService>();
builder.Services.AddTransient<ISaleService,SaleService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
