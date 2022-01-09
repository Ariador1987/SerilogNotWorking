using Microsoft.EntityFrameworkCore;
using Serilog;
using TrupjaBooks.Data;
using TrupjaBooks.Data.Services;
using TrupjaBooks.Exceptions;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Log.Logger = new LoggerConfiguration()

//Log.Logger = new LoggerConfiguration()
//    .WriteTo
//    .MSSqlServer(
//        connectionString: "Server=.\\SQLEXPRESS;Database=EtrupjaBooks;Trusted_Connection=True;MultipleActiveResultSets=True",
//        sinkOptions: new MSSqlServerSinkOptions { TableName = "Logs" })
//    .CreateLogger();



var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString)
);
builder.Services.AddScoped<BooksService>();
builder.Services.AddScoped<PublisherService>();
builder.Services.AddScoped<AuthorsService>();
//builder.Logging.AddProvider()
builder.Host.UseSerilog((context, loggingConfig) =>
    loggingConfig.WriteTo.Console().ReadFrom.Configuration(context.Configuration));


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

// Exception handling
app.ConfigureBuildInExceptionHandler();

app.MapControllers();

app.Run();
