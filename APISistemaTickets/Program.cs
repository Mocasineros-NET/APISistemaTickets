using APISistemaTickets.Authorization;
using APISistemaTickets.Data.Services;
using APISistemaTickets.Helpers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (builder.Environment.IsProduction())
    builder.Services.AddDbContext<DataContext>();
else
    builder.Services.AddDbContext<DataContext, SqliteDataContext>();

builder.Services.AddCors();
builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

//DI

builder.Services.AddScoped<IJwtUtils, JwtUtils>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ITagService, TagService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<DataContext>();    
    dataContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// global cors policy
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

// global error handler
app.UseMiddleware<ErrorHandlerMiddleware>();

// custom jwt auth middleware
app.UseMiddleware<JwtMiddleware>();

app.MapControllers();

app.Run("https://localhost:4000");