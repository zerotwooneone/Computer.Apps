using Computer.Apps.ToDoList.Integration.Bus;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Computer.Apps.ToDoList.Integration.Data;
using Computer.Apps.ToDoList.Integration.Domain;
using Computer.Bus.Contracts;
using Computer.Bus.Domain;
using Computer.Bus.ProtobuffNet;
using Computer.Bus.RabbitMq;
using Computer.Bus.RabbitMq.Contracts;
using Computer.Bus.Domain.Contracts;
using Initializer = Computer.Bus.Domain.Initializer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

//dto bus
builder.Services.AddSingleton<ISerializer, ProtoSerializer>();
builder.Services.AddSingleton<IConnectionFactory, SingletonConnectionFactory>();
builder.Services.AddSingleton<IBusClient>(serviceProvider =>
{
    var clientFactory = new ClientFactory();
    var serializer = serviceProvider.GetService<ISerializer>() ?? throw new InvalidOperationException();
    var connectionFactory = serviceProvider.GetService<IConnectionFactory>() ?? throw new InvalidOperationException();
    return clientFactory.Create(serializer , connectionFactory);
});

//domain
builder.Services.AddDomain(builder.Configuration);

builder.Services.AddHostedService<DomainStartupService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();