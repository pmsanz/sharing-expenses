using SharingExpenses.DbContexts;
using SharingExpenses.Models.DbModels;

namespace SharingExpenses.DataSeeders
{
    public class UsersDataSeeder
    {

        public readonly BaseDBContext _baseDBContext;

        public UsersDataSeeder(BaseDBContext baseDBContext)
        {
            _baseDBContext = baseDBContext;
        }


        public void Seed()
        {
            if (!_baseDBContext.Users.Any())
            {
                var newUsers = new List<Users>()
                {
                    new Users()
                    {
                        Id = 0,
                        Name = "Paul",
                        Lastname = "Thomson"
                    },
                    new Users()
                    {
                        Id = 1,
                        Name = "Ana",
                        Lastname = "Smith"
                    },
                    new Users()
                    {
                        Id = 2,
                        Name = "Bob",
                        Lastname = "Hellman"
                    },
                    new Users()
                    {
                        Id = 3,
                        Name = "Jony",
                        Lastname = "Rodriguez"
                    }
                };

                _baseDBContext.Users.AddRange(newUsers);
                _baseDBContext.SaveChanges();
            }

        }
    }
}
