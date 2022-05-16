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
                var newSeeds = new List<Users>()
                {
                    new Users()
                    {
                        
                        Name = "Jhon",
                        Lastname = "Thomson"
                    },
                    new Users()
                    {
                        
                        Name = "Peter",
                        Lastname = "Smith"
                    },
                    new Users()
                    {
                       
                        Name = "Mary",
                        Lastname = "Hellman"
                    }
                   
                };

                _baseDBContext.Users.AddRange(newSeeds);
                _baseDBContext.SaveChanges();
            }

        }
    }
}
