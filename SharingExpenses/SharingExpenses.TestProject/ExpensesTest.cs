using Microsoft.EntityFrameworkCore;
using SharingExpenses.Controllers;
using SharingExpenses.DbContexts;
using SharingExpenses.Models.DbModels;
using SharingExpenses.Models.DTO.Expenses;
using System;
using System.Collections.Generic;
using Xunit;

namespace SharingExpenses.TestProject
{
    public class ExpensesTest
    {
        DbContextOptions<BaseDBContext> _options;
        public ExpensesTest()
        {
            _options = new DbContextOptionsBuilder<BaseDBContext>()
            .UseInMemoryDatabase(databaseName: "inMemoryDataBase")
            .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BaseDBContext(_options))
            {
                var groups = new List<Groups>() { new Groups() { Id = 1, Name = "Best Travel!", TotalCost = Convert.ToDecimal("0.00") } };

                context.Groups.AddRange(groups);

                context.Users.Add(new Users { Id = 1, Name = "Jhon", Lastname = "Smith", Groups = groups });
                context.Users.Add(new Users { Id = 2, Name = "Maria", Lastname = "Helmman", Groups = groups });


                context.Expenses.Add(new Expenses { Id = 1, Name = "Expense1", Cost = Convert.ToDecimal("15.00"), GroupId = 1, OwnerId = 1 });
                context.Expenses.Add(new Expenses { Id = 2, Name = "Expense2", Cost = Convert.ToDecimal("100.00"), GroupId = 1, OwnerId = 2 });


                context.SaveChanges();
            }
        }
        [Fact]
        public void Test_Correct_Numbers_Of_Expenses()
        {
            

            // Use a clean instance of the context to run the test
            using (var context = new BaseDBContext(_options))
            {
                var controller = new ExpensesController(context);
                var response = controller.GetExpenses(1);

                ExpensesDTO[] expensesArray = (ExpensesDTO[])response;

                Assert.Equal(2, expensesArray.Length);
    
            
            }
                        


        }

        [Fact]
        public void Test_Modify_Expenses()
        {


            // Use a clean instance of the context to run the test
            using (var context = new BaseDBContext(_options))
            {
                var controller = new ExpensesController(context);
                ExpensesDTO_Edit expensesDTO = new ExpensesDTO_Edit() { 
                    
                    Id = 1,
                    Name = "Garage",
                    Cost = Convert.ToDecimal(333),
                    User = 1,
                    Group = 1
                                    
                };

                var response = controller.AddOrUpdateExpenses(expensesDTO);

                Assert.Equal(expensesDTO.Id, response.Id);
                Assert.Equal(expensesDTO.Name, response.Name);
                Assert.Equal(expensesDTO.Cost, response.Cost);
                Assert.Equal("Jhon", response.User);
                Assert.Equal("Best Travel!", response.Group);


            }



        }
        [Fact]
        public void Test_Add_Expenses()
        {


            // Use a clean instance of the context to run the test
            using (var context = new BaseDBContext(_options))
            {
                var controller = new ExpensesController(context);
                ExpensesDTO_Edit expensesDTO = new ExpensesDTO_Edit()
                {

                    
                    Name = "Garage",
                    Cost = Convert.ToDecimal(333),
                    User = 1,
                    Group = 1

                };

                var response = controller.AddOrUpdateExpenses(expensesDTO);

                Assert.Equal(3,expensesDTO.Id);
                Assert.Equal(expensesDTO.Name, response.Name);
                Assert.Equal(expensesDTO.Cost, response.Cost);
                Assert.Equal("Jhon", response.User);
                Assert.Equal("Best Travel!", response.Group);


            }



        }

        [Fact]
        public void Test_Expenses_Not_Found()
        {


            // Use a clean instance of the context to run the test
            using (var context = new BaseDBContext(_options))
            {
                var controller = new ExpensesController(context);
                var response = controller.GetExpenses(3);

                ExpensesDTO[] expensesArray = (ExpensesDTO[])response;

                Assert.Empty(expensesArray);


            }



        }
    }
}