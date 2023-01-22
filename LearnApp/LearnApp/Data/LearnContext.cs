using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using LearnApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BetApp.Data;

internal class learnContext : DbContext
{
    public DbSet<Employees> Employees { get; set; }
    public DbSet<Building> Building { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
            "server=localhost;" +    // Server name
            "port=3306;" +           // Port number
            "user=root;" +           // The user
            "password=;" +  // The password
            "database=learnapp"      // Database name
            , Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.17-mariadb"));
        }
    }
}
