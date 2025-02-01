using Microsoft.EntityFrameworkCore;

namespace SpendSmart.Models
{
    public class ExpensesDB : DbContext
    {

        public DbSet<Expenses> ExpenseTable { get; set; }

        public ExpensesDB(DbContextOptions<ExpensesDB> options) : base(options)
        {

        }

    }
}
