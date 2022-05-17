#define TEST
using Microsoft.EntityFrameworkCore;
using SharingExpenses.Controllers;
using SharingExpenses.DbContexts;
using SharingExpenses.Models.DbModels;
using SharingExpenses.Models.DTO.Expenses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace SharingExpenses.TestProject
{
    public class ExpensesTest : TestsBase
    {
        
        [Fact]
        public void Test_Correct_Numbers_Of_Expenses()
        {
            

            var controller = new ExpensesController(_context);
            var response = controller.GetExpenses(1);
            ExpensesDTO[] expensesArray = (ExpensesDTO[])response;

            Assert.Equal(2, expensesArray.Length);
    

        }

        [Fact]
        public void Test_Modify_Expenses()
        {
                       
                var controller = new ExpensesController(_context);
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
        [Fact]
        public void Test_Add_Expenses()
        {
            
            var controller = new ExpensesController(_context);
            ExpensesDTO_Edit expensesDTO = new ExpensesDTO_Edit()
            {

                Name = "Garage",
                Cost = Convert.ToDecimal(333),
                User = 1,
                Group = 1

            };

            var response = controller.AddOrUpdateExpenses(expensesDTO);

            Assert.Equal(3, response.Id);
            Assert.Equal(expensesDTO.Name, response.Name);
            Assert.Equal(expensesDTO.Cost, response.Cost);
            Assert.Equal("Jhon", response.User);
            Assert.Equal("Best Travel!", response.Group);


        }

        [Fact]
        public void Test_Expenses_Not_Found()
        {

            var controller = new ExpensesController(_context);
            var response = controller.GetExpenses(3);
            ExpensesDTO[] expensesArray = (ExpensesDTO[])response;
            Assert.Empty(expensesArray);

        }



        [Fact]
        public void Test_GetCorrectQuantityUsersTwo()
        {
           
            
            var controller = new ExpensesController(_context);
            var response = controller.GetResultingPayments(1);
            Assert.Equal(2, response.Count());

            

        }

        [Fact]
        public void Test_GetCorrectQuantityUsersThree()
        {

            var newCost = 100;
            Add_ThirdUser(newCost);
            var controller = new ExpensesController(_context);
            var response = controller.GetResultingPayments(1);
            Assert.Equal(3, response.Count());

        }

        [Fact]
        public void Test_GetCorrectTotal()
        {
            
            var controller = new ExpensesController(_context);
            var response = controller.GetResultingPayments(1);

            var sum_pay = response.Sum(x => x.Must_Pay);
            var sum_receive = response.Sum(x => x.Must_Receive);

            Assert.Equal(sum_pay, sum_receive);

        }


        public void Add_ThirdUser(int newCost)
        {
                       
            var groups = _context.Groups.Where(x => x.Id.Equals(1)).ToList();
            var group = groups.FirstOrDefault();
            group.TotalCost = group.TotalCost + newCost;

            _context.Users.Add(new Users { Id = 3, Name = "Peter", Lastname = "Carlsberg", Groups = groups });
            _context.Expenses.Add(new Expenses { Id = 4, Name = "Various", Cost = Convert.ToDecimal(newCost), Group = group, OwnerId = 3 });

            
            _context.SaveChanges();
                        

        }

        
    }
}