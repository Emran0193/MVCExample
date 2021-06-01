using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVCExample.Models
{
    public partial class EmployeeContext : DbContext
    {
        public EmployeeContext()
        {
        }

        public EmployeeContext(DbContextOptions<EmployeeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Employee1> Employees1 { get; set; }
        public virtual DbSet<Salary> Salaries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Department");

                entity.Property(e => e.DeptName).HasMaxLength(20);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpId)
                    .HasName("pk_Employee");

                entity.ToTable("Employee");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.EmpSalary).HasColumnType("money");

                entity.Property(e => e.JoiningDate).HasColumnType("datetime");

                entity.Property(e => e.NetSalary).HasColumnType("money");

                entity.Property(e => e.Tds)
                    .HasColumnType("money")
                    .HasColumnName("TDS");
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Employees");

                entity.Property(e => e.EmpName).HasMaxLength(20);
            });

            modelBuilder.Entity<Salary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Salary");

                entity.Property(e => e.Sal).HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
