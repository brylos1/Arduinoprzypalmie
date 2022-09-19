using System;
using Microsoft.EntityFrameworkCore;
using TemperaturyAPI.Models;

namespace TemperaturyAPI.Database
{
    public class MysqlDbContext:DbContext
    {
        public MysqlDbContext(DbContextOptions<MysqlDbContext> options) : base(options)
        {
        }
        public DbSet<DaneZPalmyModel> temperaturies { get; set; }
        public DbSet<SrednieTemperaturyModel> srednieTemperatury { get; set; }
        public DbSet<MinMaxModel> minMax { get; set; }
    }
}

