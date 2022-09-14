using System;
using Microsoft.EntityFrameworkCore;

namespace OdczytDanych.entities
{
    public class MyDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(@"server=192.168.1.6;user=root;database=temperatury;password=Luki1234;port=3306", ServerVersion.AutoDetect(@"server=192.168.1.6;user=root;database=temperatury;password=Luki1234;port=3306"));
        }
        public DbSet<Temperatury> temperaturies { get; set; }
    }
}

