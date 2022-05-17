using Microsoft.EntityFrameworkCore;
using SharingExpenses.DbContexts;
using SharingExpenses.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace SharingExpenses.TestProject
{
    public abstract class TestsBase : IDisposable
    {
        public BaseDBContext? _context;
        protected TestsBase()
        {
            
            if (_context == null)
            {
                var options = new DbContextOptionsBuilder<BaseDBContext>()
                                   .UseInMemoryDatabase(databaseName: "inMemoryDataBase")
                                   .Options;

                _context = new BaseDBContext(options);
            }
                        
            List<Groups> groups = new() { new Groups() { Id = 1, Name = "Best Travel!", TotalCost = Convert.ToDecimal("650.00") } };

            _context.Groups.AddRange(groups);
            
            _context.Users.Add(new Users { Id = 1, Name = "Jhon", Lastname = "Smith", Groups = groups });
            _context.Users.Add(new Users { Id = 2, Name = "Mary", Lastname = "Helmman", Groups = groups });

            _context.Expenses.Add(new Expenses { Id = 1, Name = "Hotel", Cost = Convert.ToDecimal("500.00"), GroupId = 1, OwnerId = 1 });
            _context.Expenses.Add(new Expenses { Id = 2, Name = "Restaurant", Cost = Convert.ToDecimal("150.00"), GroupId = 1, OwnerId = 2 });

            _context.SaveChanges();

        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.RemoveRange(_context.Users.ToArray());
                _context.RemoveRange(_context.Groups.ToArray());
                _context.RemoveRange(_context.Expenses.ToArray());
                _context.SaveChanges();

                _context.Dispose();
            }
                
        }
    }

    
}
