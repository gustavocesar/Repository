using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using Domain.Entities;
using Infrastructure.Persistence.Mappings;
using SharedKernel.Infrastructure.DataContext;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Context
{
    public class DataContext : DbContext, IDataContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DataContext()
        {
        }

        public DbSet<Foo> Foo { get; set; }
        public DbSet<Bar> Bar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FooMap());
            modelBuilder.ApplyConfiguration(new BarMap());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                     .SetBasePath(Directory.GetCurrentDirectory() + "/../../Api")
                     .AddJsonFile("appsettings.json", false, true)
                     .Build();
                var connectionString = configuration.GetConnectionString("MyConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
