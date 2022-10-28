using Microsoft.EntityFrameworkCore;
using MigrationDbForEF.SqlServerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MigrationDbForEF.EfDbContext
{
    public class SqlServerDbContext:DbContext
    {
        public SqlServerDbContext(DbContextOptions<SqlServerDbContext> options):base(options)
        {
            this.Database.SetCommandTimeout(60000);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<VIEW_PATIENT_BASEINFO>(entity =>
            {
                //告诉EF Core实体V_STORAGE_LIST对应数据库中的V_STORAGE_LIST视图
                entity.ToTable("VIEW_PATIENT_BASEINFO");
                //设置实体的唯一属性ID
                entity.HasNoKey();
            });
            modelBuilder.Entity<VIEW_PATIENT_DIAG>(entity =>
            {
                //告诉EF Core实体V_STORAGE_LIST对应数据库中的V_STORAGE_LIST视图
                entity.ToTable("VIEW_PATIENT_DIAG");
                //设置实体的唯一属性ID
                entity.HasNoKey();
            });
            modelBuilder.Entity<VIEW_PATIENT_VISITINFO>(entity =>
            {
                //告诉EF Core实体V_STORAGE_LIST对应数据库中的V_STORAGE_LIST视图
                entity.ToTable("VIEW_PATIENT_VISITINFO");
                //设置实体的唯一属性ID
                entity.HasNoKey();
            });
            modelBuilder.Entity<VIEW_PATIENT_ORDERS>(entity =>
            {
                //告诉EF Core实体V_STORAGE_LIST对应数据库中的V_STORAGE_LIST视图
                entity.ToTable("VIEW_PATIENT_ORDERS");
                //设置实体的唯一属性ID
                entity.HasNoKey();
            });
            modelBuilder.Entity<VIEW_LAB>(entity =>
            {
                //告诉EF Core实体V_STORAGE_LIST对应数据库中的V_STORAGE_LIST视图
                entity.ToTable("VIEW_LAB");
                //设置实体的唯一属性ID
                entity.HasNoKey();
            });
            modelBuilder.Entity<VIEW_LAB_ITEM>(entity =>
            {
                //告诉EF Core实体V_STORAGE_LIST对应数据库中的V_STORAGE_LIST视图
                entity.ToTable("VIEW_LAB_ITEM");
                //设置实体的唯一属性ID
                entity.HasNoKey();
            });
            modelBuilder.Entity<VIEW_EXAM>(entity =>
            {
                //告诉EF Core实体V_STORAGE_LIST对应数据库中的V_STORAGE_LIST视图
                entity.ToTable("VIEW_EXAM");
                //设置实体的唯一属性ID
                entity.HasNoKey();
            });
            modelBuilder.Entity<VIEW_VITAL_SIGNS>(entity =>
            {
                //告诉EF Core实体V_STORAGE_LIST对应数据库中的V_STORAGE_LIST视图
                entity.ToTable("VIEW_VITAL_SIGNS");
                //设置实体的唯一属性ID
                entity.HasNoKey();
            });
        }

        public virtual DbSet<VIEW_PATIENT_BASEINFO> VIEW_PATIENT_BASEINFO { get; set; }
        public virtual DbSet<VIEW_PATIENT_DIAG> VIEW_PATIENT_DIAG { get; set; }
        public virtual DbSet<VIEW_PATIENT_VISITINFO> VIEW_PATIENT_VISITINFO { get; set; }
        public virtual DbSet<VIEW_PATIENT_ORDERS> VIEW_PATIENT_ORDERS { get; set; }
        public virtual DbSet<VIEW_LAB> VIEW_LAB { get; set; }
        public virtual DbSet<VIEW_LAB_ITEM> VIEW_LAB_ITEM { get; set; }
        public virtual DbSet<VIEW_EXAM> VIEW_EXAM { get; set; }
        public virtual DbSet<VIEW_VITAL_SIGNS> VIEW_VITAL_SIGNS { get; set; }
    }
}
