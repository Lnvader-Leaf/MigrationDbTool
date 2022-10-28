using Microsoft.EntityFrameworkCore;
using MigrationDbForEF.MySqlEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.EfDbContext
{
    public class MySqlDbContext:DbContext
    {
        public MySqlDbContext(DbContextOptions<MySqlDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VIEW_OPERATION>().HasKey(m => m.RECORD_FLOW);
        }

        public DbSet<VIEW_OPERATION> VIEW_OPERATION { get; set; }
    }
}
