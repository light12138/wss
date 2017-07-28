using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wss.TestWeb.Model
{
    public class Sqlcontest: DbContext
    {
        public Sqlcontest(DbContextOptions option) : base(option)
        {

        }

        public DbSet<T_Test> Test { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
