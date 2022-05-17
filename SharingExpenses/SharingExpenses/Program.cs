using Microsoft.EntityFrameworkCore;
using SharingExpenses.DataSeeders;
using SharingExpenses.DbContexts;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllers();

#region SEEDERS
//seeders
builder.Services.AddTransient<UsersDataSeeder>();
builder.Services.AddTransient<GroupsDataSeeder>();
builder.Services.AddTransient<ExpensesDataSeeder>();
#endregion

////contexts
builder.Services.AddDbContext<BaseDBContext>(x => x.UseSqlServer(connectionString));

#region METHODS
//methods
void SeedData(IHost host)
{
    var scopedFactory = host.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        
        var groups = scope.ServiceProvider.GetService<GroupsDataSeeder>();
        groups.Seed();

        var users = scope.ServiceProvider.GetService<UsersDataSeeder>();
        users.Seed();

        var expenses = scope.ServiceProvider.GetService<ExpensesDataSeeder>();
        expenses.Seed();
    }

}

#endregion

var app = builder.Build();

#if DEBUG
SeedData(app);
#endif

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();