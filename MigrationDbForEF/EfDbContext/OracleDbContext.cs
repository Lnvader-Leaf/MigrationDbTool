using Microsoft.EntityFrameworkCore;
using MigrationDbForEF.OracleEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.EfDbContext
{
    public class OracleDbContext:DbContext
    {
        public OracleDbContext(DbContextOptions<OracleDbContext> options):base(options)
        {
            this.Database.SetCommandTimeout(60000);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VIEW_PATIENT_BASEINFO>().HasKey(m=>m.IID);
            modelBuilder.Entity<VIEW_PATIENT_DIAG>().HasKey(m=>m.IID);
            modelBuilder.Entity<VIEW_PATIENT_VISITINFO>().HasKey(m=>m.IID);
            modelBuilder.Entity<VIEW_VITAL_SIGNS2>().HasKey(m=>m.IID);
            modelBuilder.Entity<VIEW_PATIENT_ORDERS>().HasKey(m=>m.IID);
            modelBuilder.Entity<VIEW_LAB>().HasKey(m=>m.IID);
            modelBuilder.Entity<VIEW_LAB_ITEM>().HasKey(m=>m.IID);
            modelBuilder.Entity<VIEW_EXAM>().HasKey(m=>m.IID);
            modelBuilder.Entity<VIEW_OPERATION>().HasKey(m=>m.IID);
            modelBuilder.Entity<JZMould>().HasKey(m=>m.IID);
        }

        public virtual DbSet<VIEW_PATIENT_BASEINFO> VIEW_PATIENT_BASEINFO { get; set; }
        public virtual DbSet<VIEW_PATIENT_DIAG> VIEW_PATIENT_DIAG { get; set; }
        public virtual DbSet<VIEW_PATIENT_VISITINFO> VIEW_PATIENT_VISITINFO { get; set; }
        public virtual DbSet<VIEW_PATIENT_ORDERS> VIEW_PATIENT_ORDERS { get; set; }
        public virtual DbSet<VIEW_LAB> VIEW_LAB { get; set; }
        public virtual DbSet<VIEW_LAB_ITEM> VIEW_LAB_ITEM { get; set; }
        public virtual DbSet<VIEW_EXAM> VIEW_EXAM { get; set; }
        public virtual DbSet<VIEW_OPERATION> VIEW_OPERATION { get; set; }
        public virtual DbSet<JZMould> QCT_JZAI { get; set; }
        public virtual DbSet<VIEW_VITAL_SIGNS2> VIEW_VITAL_SIGNS2 { get; set; }
    }
}
