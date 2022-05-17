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
                var groups = _baseDBContext.Groups.Where(x => x.Name.Equals("Amazing Holiday's Travel!!!")).ToArray();
                if (groups == null)
                    throw new Exception();

                var newSeeds = new List<Users>()
                {
                    new Users()
                    {
                        
                        Name = "Jhon",
                        Lastname = "Thomson",
                        Groups = groups
                    },
                    new Users()
                    {
                        
                        Name = "Peter",
                        Lastname = "Smith",
                        Groups = groups
                    },
                    new Users()
                    {
                       
                        Name = "Mary",
                        Lastname = "Hellman",
                        Groups = groups
                    }
                   
                };

                _baseDBContext.Users.AddRange(newSeeds);
                _baseDBContext.SaveChanges();
            }

        }
    }
}
