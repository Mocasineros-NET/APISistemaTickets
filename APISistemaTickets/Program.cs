using System.Text.Json.Serialization;
using APISistemaTickets.Modules.Authorization;
using APISistemaTickets.Modules.Comments.Domain.Abstractions;
using APISistemaTickets.Modules.Comments.Domain.Services;
using APISistemaTickets.Modules.Helpers;
using APISistemaTickets.Modules.KnowledgeBase.Domain.Abstractions;
using APISistemaTickets.Modules.KnowledgeBase.Domain.Services;
using APISistemaTickets.Modules.Tags.Domain.Abstractions;
using APISistemaTickets.Modules.Tags.Domain.Services;
using APISistemaTickets.Modules.Tickets.Domain.Abstractions;
using APISistemaTickets.Modules.Tickets.Domain.Services;
using APISistemaTickets.Modules.UserAdministration.Domain.Abstractions;
using APISistemaTickets.Modules.UserAdministration.Domain.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

if (builder.Environment.IsProduction())
{
    Console.WriteLine("Using production database");
    builder.Services.AddDbContext<DataContext>();
}
else
{
    Console.WriteLine("Using development database");
    builder.Services.AddDbContext<DataContext, SqliteDataContext>();
}

builder.Services.AddCors();
builder.Services.AddControllers().AddJsonOptions(x =>
    x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

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
// if (app.Environment.IsDevelopment())
// {
    app.UseSwagger();
    app.UseSwaggerUI();
// }

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

app.Run();