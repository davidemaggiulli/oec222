using Microsoft.EntityFrameworkCore;
using OEC222.Pizzeria.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEC222.Pizzeria.Core.EF
{
    public class PizzeriaDbContext : DbContext
    {
        public PizzeriaDbContext()
        {
            this.Database.EnsureCreated();
        }

        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options) : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.LogTo((s) => System.Console.WriteLine(s));
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=.\SQLEXPRESS;Initial Catalog=Pizzeria;Integrated Security=true;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pizza>().ToTable("Pizza");
            builder.Entity<Pizza>().HasKey(x => x.Code);
            builder.Entity<Pizza>().Property(x => x.Code).IsRequired().HasColumnType("char").HasMaxLength(3);
            builder.Entity<Pizza>().Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<Pizza>().Property(x => x.Price).HasColumnType("decimal(8,4)");

            builder.Entity<Ingredient>().ToTable("Ingredient");
            builder.Entity<Ingredient>().HasKey(x => x.Code);
            builder.Entity<Ingredient>().Property(x => x.Code).IsRequired().HasColumnType("char").HasMaxLength(3);
            builder.Entity<Ingredient>().Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(50);
            builder.Entity<Ingredient>().Property(x => x.Cost).HasColumnType("decimal(8,4)");
            builder.Entity<Ingredient>().Property(x => x.Stock).HasColumnType("decimal(8,4)");

            builder.Entity<Composition>().ToTable("Composition");
            builder.Entity<Composition>().HasKey(x => new { x.PizzaCode, x.IngredientCode });
            builder.Entity<Composition>().Property(x => x.PizzaCode).IsRequired().HasColumnType("char").HasMaxLength(3);
            builder.Entity<Composition>().Property(x => x.IngredientCode).IsRequired().HasColumnType("char").HasMaxLength(3);

            builder.Entity<Composition>()
                .HasOne(x => x.Pizza)
                .WithMany(x => x.Compositions)
                .HasForeignKey(x => x.PizzaCode);

            builder.Entity<Composition>()
                .HasOne(x => x.Ingredient)
                .WithMany()
                .HasForeignKey(x => x.IngredientCode);

        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Composition> Compositions { get; set; }
    }
}
