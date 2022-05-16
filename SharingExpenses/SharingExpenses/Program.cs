using Microsoft.EntityFrameworkCore;
using SharingExpenses.DataSeeders;
using SharingExpenses.DbContexts;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


builder.Services.AddTransient<UsersDataSeeder>();
builder.Services.AddDbContext<BaseDBContext>(x => x.UseSqlServer(connectionString));

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

app.MapGet("/", () => "Hello World!");

app.Run();


void SeedData(IHost host)
{
    var scopedFactory = host.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<UsersDataSeeder>();
        service.Seed();
    } 
        
}
