using Facebook.Application;
using Facebook.Infrastructure;
using Facebook.Infrastructure.Common.Initializers;
using Facebook.Server;
using Facebook.Server.Common;
using Facebook.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

//NLog
//builder.Logging.ClearProviders();
//builder.Logging.SetMinimumLevel(LogLevel.Trace);
//builder.Host.UseNLog();

builder.Services.AddCors(options =>
{
    options.AddPolicy("StaticFilesCorsPolicy", builder =>
    {
        builder.WithOrigins("http://localhost:5173")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error");
    app.UseHsts();
}

app.UseCors("StaticFilesCorsPolicy");

app.UseCustomStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chatHub");

UserAndRolesInitializer.SeedData(app);
ActionsSeeder.SeedData(app);
FeelingsSeeder.SeedData(app);

app.Run();
