﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using WebAPI_EFCompany.Model;

namespace WebAPI_EFCompany
{
    public class Context:DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Department> Departments { get; set; }

        public Context()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source=Company.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().OwnsOne(m => m.Member);
            modelBuilder.Entity<Employee>().HasOne(e=>e.Position).WithMany(p=>p.Employees).HasForeignKey(e=>e.PositionId);
            modelBuilder.Entity<Position>().HasOne(p => p.Head);
        }
    }
}
