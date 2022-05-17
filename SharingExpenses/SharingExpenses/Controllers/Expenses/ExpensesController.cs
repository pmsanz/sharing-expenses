using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharingExpenses.DbContexts;
using SharingExpenses.Models.DbModels;
using SharingExpenses.Models.DTO.Expenses;

namespace SharingExpenses.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly BaseDBContext _context;

        public ExpensesController(BaseDBContext context) => _context = context;

        [HttpGet("{groupid}")]
        public IEnumerable<ExpensesDTO> GetExpenses(int groupid)
        {

            var expenses = _context.Expenses
                .AsNoTracking()
                .Include(x => x.Owner)
                .Include(x => x.Group)
                .Where(x => x.GroupId.Equals(groupid));

            // A mapping would be a elegant solution, oposite at this I will use a foreach to fill the DTOs
            ExpensesDTO[] expensesArray = new ExpensesDTO[expenses.Count()];
            int index = 0;

            foreach (var item in expenses)
            {
                var expense = new ExpensesDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Cost = item.Cost,
                    User = item.Owner.Name,
                    Group = item.Group.Name
                };

                expensesArray[index] = expense;
                index++;
            }

            return expensesArray;

        }

        [HttpPost]
        public ExpensesDTO AddOrUpdateExpenses([FromBody] ExpensesDTO_Edit expensesDTO_Edit)
        {
            //if exists id -> update, else create expenses
            var expense = new Expenses();

            var group = _context.Groups
                .Include(x => x.Users)
                .Include(x => x.Expenses)
                .Include(x => x.Payments)
                .FirstOrDefault(x => x.Id.Equals(expensesDTO_Edit.Group));

            var user = _context.Users.AsNoTracking().FirstOrDefault(x => x.Id.Equals(expensesDTO_Edit.User));

            if (expensesDTO_Edit.Id == null)
            {



                if (user != null && group != null)
                {
                    expense = new Expenses()
                    {
                        Cost = expensesDTO_Edit.Cost,
                        OwnerId = user.Id,
                        GroupId = group.Id,
                        Name = expensesDTO_Edit.Name
                    };

                    _context.Expenses.Add(expense);
                    _context.SaveChanges();


                }
                else
                {
                    throw new Exception("Data is not correct, verify user && group");
                }


            }
            else
            {
                expense = _context.Expenses.FirstOrDefault(x => x.Id.Equals(expensesDTO_Edit.Id));

                if (expense == null)
                    throw new Exception("Id doesn't exists in the Data Base.");

                expense.Name = expensesDTO_Edit.Name;
                expense.Cost = expensesDTO_Edit.Cost;

                _context.Expenses.Update(expense);
                _context.SaveChanges();


            }


            //update group TotalCost
            var cost = _context.Expenses.Where(x => x.GroupId.Equals(expense.GroupId)).Sum(x => x.Cost);
            group.TotalCost = cost;

            _context.Groups.Update(group);
            _context.SaveChanges();

            //mapping

            ExpensesDTO result = new ExpensesDTO()
            {
                Id = expense.Id,
                Name = expense.Name,
                Cost = expense.Cost,
                User = user.Name,
                Group = expense.Group.Name

            };

            return result;

        }

        [HttpGet("{groupid}")]
        public IEnumerable<ExpensesBringBackDTO> GetResultingPayments(int groupid)
        {
            
            var group = _context.Groups
                .AsNoTracking()
                .FirstOrDefault(x => x.Id.Equals(groupid));

            if (group == null)
                throw new Exception("Group doesn't exists.");

            var expenses_by_users = _context.Expenses
                .AsNoTracking()
                .Include(x => x.Owner)
                .Where(x => x.GroupId.Equals(groupid))
                .GroupBy( x => x.OwnerId)
                .Select( g => new {
                                    UserId = g.First().OwnerId,
                                    Value = g.Sum(s => s.Cost) 
                                  })
                .ToDictionary( x => x.UserId, x => x.Value);

            var users = _context.Users
                .AsNoTracking()
                .Include(x => x.Groups)
                .Where(x => x.Groups.Contains(group));

            var count_users = users.Count();

            decimal total_cost = group.TotalCost;

            ExpensesBringBackDTO[] result = new ExpensesBringBackDTO[count_users];

            if (count_users > 0)
            {
                var total_per_user = total_cost / count_users;
                
                int index = 0;

                foreach (var user in users)
                {
                    decimal expended_by_user = 0;
                    ExpensesBringBackDTO dto = new ExpensesBringBackDTO();
                    
                    dto.User = String.Format("{0} {1}", user.Name, user.Lastname);

                    if (expenses_by_users.TryGetValue(user.Id, out expended_by_user))
                    {
                        if (expended_by_user > total_per_user)
                            dto.Must_Receive = expended_by_user - total_per_user;
                        else
                            dto.Must_Pay = total_per_user - expended_by_user;
                    }
                    else
                    {
                        dto.Must_Pay = total_per_user;
                    }

                    result[index++] = dto;

                }

            }

            return result;

        }
    }
}