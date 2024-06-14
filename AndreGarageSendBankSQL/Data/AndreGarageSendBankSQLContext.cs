using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AndreGarageSendBankSQL.Data
{
    public class AndreGarageSendBankSQLContext : DbContext
    {
        public AndreGarageSendBankSQLContext (DbContextOptions<AndreGarageSendBankSQLContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Bank> Bank { get; set; } = default!;
    }
}
