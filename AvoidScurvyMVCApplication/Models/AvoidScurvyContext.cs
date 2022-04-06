using System;
using System.Collections.Generic;
using AvoidScurvyMVCApplication.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


public class AvoidScurvyContext : IdentityDbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductViewing> ProductViewings { get; set; }

    public AvoidScurvyContext(DbContextOptions<AvoidScurvyContext> options) : base (options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Product>().HasData(new Product()
        //{
        //    Calories = 100,
        //    Name = "oranges"
        //});
        base.OnModelCreating(modelBuilder);
    }
}
