using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankTransactions.Models
{
    public class TransactionDbContext:DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> option) : base(option)
        {

        }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
