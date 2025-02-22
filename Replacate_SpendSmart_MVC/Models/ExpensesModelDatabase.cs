using Microsoft.EntityFrameworkCore;

namespace Replacate_SpendSmart_MVC.Models
{
    public class ExpensesModelDatabase : DbContext
    {
        public DbSet<ExpensesModel> ExpensesData { get; set; }

        public ExpensesModelDatabase(DbContextOptions<ExpensesModelDatabase> options) 
            : base(options)
        {
            
        }

    }
}
