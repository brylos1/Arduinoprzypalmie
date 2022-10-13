using System;
using Microsoft.EntityFrameworkCore;

namespace OdczytDanych.entities
{
    public class PgsqlDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=192.168.1.5;Database=temperatury;Username=mateusz;Password=Luki1234");
        }
        public DbSet<Temperatury> temperaturies { get; set; }
    }
}

