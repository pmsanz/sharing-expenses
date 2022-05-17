using SharingExpenses.DbContexts;
using SharingExpenses.Models.DbModels;

namespace SharingExpenses.DataSeeders
{
    public class GroupsDataSeeder
    {

        public readonly BaseDBContext _baseDBContext;

        public GroupsDataSeeder(BaseDBContext baseDBContext)
        {
            _baseDBContext = baseDBContext;
        }

        public void Seed()
        {
            if (!_baseDBContext.Groups.Any())
            {
                var newSeeds = new List<Groups>()
                {
                    new Groups()
                    {

                        Name = "Amazing Holiday's Travel!!!",
                        Users = _baseDBContext.Users.Take(4).ToList(),
                        Payments = new List<Payments>(),
                        Expenses = new List<Expenses>(),
                        TotalCost = Convert.ToDecimal(750.00)

                    }
                };

                _baseDBContext.Groups.AddRange(newSeeds);
                _baseDBContext.SaveChanges();
            }

        }
    }
}
