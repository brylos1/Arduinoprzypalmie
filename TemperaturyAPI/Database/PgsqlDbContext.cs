using System;
using Microsoft.EntityFrameworkCore;
using TemperaturyAPI.Models;

namespace TemperaturyAPI.Database
{
    public class PgsqlDbContext:DbContext
    {
        public PgsqlDbContext(DbContextOptions<PgsqlDbContext> options) : base(options)
        {
        }
        public DbSet<DaneZPalmyModel> temperaturies { get; set; }
        public DbSet<SrednieTemperaturyModel> srednieTemperatury { get; set; }
        public DbSet<MinMaxModel> minMax { get; set; }
    }
}

