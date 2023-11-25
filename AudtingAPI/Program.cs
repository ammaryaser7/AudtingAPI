using AudtingAPI.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var str = builder.Configuration.GetConnectionString("constr");

builder.Services.AddDbContext<AuditDB>
	(options => options.UseSqlServer(str));

string MyOrigins = "_myOrigins";

builder.Services.AddCors(options => {
	options.AddPolicy(name: MyOrigins, policy =>
	{
		// the link below is for api domain
		policy.WithOrigins("https://localhost:3000/")
		.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
	}); // end policy


});// end addCors

builder.Services.AddControllers().AddNewtonsoftJson(x =>
 x.SerializerSettings.ReferenceLoopHandling =
 ReferenceLoopHandling.Ignore);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseCors(MyOrigins);


app.MapControllers();

app.Run();
