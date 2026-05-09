using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4.Infrastructure;

public class AppDbContext(DbContextOptions db) : DbContext(db)
{
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentManufactures> ComponentManufactures { get; set; }
    public DbSet<ComponentTypes> ComponentTypes { get; set; }
    public DbSet<Pc> Pc { get; set; }
    public DbSet<PcComponent> PcComponent { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Pc>().HasData([
            new Pc()
            {
                Id = 1,
                Name = "Pc 1",
                Weight = 5.69f,
                Warranty = 5,
                CreatedAt = new DateTime(2024, 5, 6),
                Stock = 1
            },
            new Pc()
            {
                Id = 2,
                Name = "Pc 2",
                Weight = 4.5f,
                Warranty = 3,
                CreatedAt = new DateTime(2026, 5, 6),
                Stock = 3
            },
            new Pc()
            {
                Id = 3,
                Name = "Pc 3",
                Weight = 45.619f,
                Warranty = 2,
                CreatedAt = new DateTime(2025, 5, 6),
                Stock = 22
            }
        ]);
        
        modelBuilder.Entity<ComponentTypes>().HasData([
            new ComponentTypes()
            {
                Id = 1,
                Abbreviation = "CT1",
                Name = "Component Type 1",
            },
            new ComponentTypes()
            {
                Id = 2,
                Abbreviation = "CT2",
                Name = "Component Type 2",
            },
            new ComponentTypes()
            {
                Id = 3,
                Abbreviation = "CT3",
                Name = "Component Type 3",
            }
        ]);

        modelBuilder.Entity<ComponentManufactures>().HasData([
            new ComponentManufactures()
            {
                Id = 1,
                Abbreviation = "C1",
                FullName = "Component Manufacture 1",
                FoundationDate = new DateTime(2021, 5, 6)
            },
            new ComponentManufactures()
            {
                Id = 2,
                Abbreviation = "C2",
                FullName = "Component Manufacture 2",
                FoundationDate = new DateTime(2022, 5, 6)
            },
            new ComponentManufactures()
            {
                Id = 3,
                Abbreviation = "C3",
                FullName = "Component Manufacture 3",
                FoundationDate = new DateTime(2011, 5, 6)
            }
        ]);

        modelBuilder.Entity<Component>().HasData([
            new Component()
            {
                Code = "Code1",
                Name = "Component 1",
                Description = "Description 1",
                ComponentManufacturersId = 1,
                ComponentTypesId = 1
            },
            new Component()
            {
                Code = "Code2",
                Name = "Component 2",
                Description = "Description 2",
                ComponentManufacturersId = 2,
                ComponentTypesId = 2
            },
            new Component()
            {
                Code = "Code3",
                Name = "Component 3",
                Description = "Description 3",
                ComponentManufacturersId = 3,
                ComponentTypesId = 3
            }
        ]);

        modelBuilder.Entity<PcComponent>().HasData([
            new PcComponent()
            {
                PcId = 1,
                ComponentCode = "Code1",
                Amount = 5
            },
            new PcComponent()
            {
                PcId = 2,
                ComponentCode = "Code2",
                Amount = 44
            },
            new PcComponent()
            {
                PcId = 3,
                ComponentCode = "Code3",
                Amount = 5
            }
        ]);
    }
}