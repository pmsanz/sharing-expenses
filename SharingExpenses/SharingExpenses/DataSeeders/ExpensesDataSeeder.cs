using SharingExpenses.DbContexts;
using SharingExpenses.Models.DbModels;

namespace SharingExpenses.DataSeeders
{
    public class ExpensesDataSeeder
    {

        public readonly BaseDBContext _baseDBContext;

        public ExpensesDataSeeder(BaseDBContext baseDBContext)
        {
            _baseDBContext = baseDBContext;
        }

        public void Seed()
        {
            if (!_baseDBContext.Expenses.Any())
            {
                var newSeeds = new List<Expenses>()
                {
                    new Expenses()
                    {
                        Name =  "Hotel",
                        Cost = 500,
                        Owner = _baseDBContext.Users.FirstOrDefault( x => x.Name.ToLower().Equals("jhon")),
                        Group = _baseDBContext.Groups.FirstOrDefault( x => x.Name.ToLower().Equals("Amazing Holiday's Travel!!!"))

                    },
                    new Expenses()
                    {
                        Name =  "Restaurant",
                        Cost = 150,
                        Owner = _baseDBContext.Users.FirstOrDefault( x => x.Name.ToLower().Equals("mary")),
                        Group = _baseDBContext.Groups.FirstOrDefault( x => x.Name.ToLower().Equals("Amazing Holiday's Travel!!!"))

                    },
                    new Expenses()
                    {
                        Name =  "Sightseeing",
                        Cost = 100,
                        Owner = _baseDBContext.Users.FirstOrDefault( x => x.Name.ToLower().Equals("peter")),
                        Group = _baseDBContext.Groups.FirstOrDefault( x => x.Name.ToLower().Equals("Amazing Holiday's Travel!!!"))

                    }
                };

                _baseDBContext.Expenses.AddRange(newSeeds);
                _baseDBContext.SaveChanges();
            }

        }
    }
}
