using ApbdCw7.Models;
using Microsoft.EntityFrameworkCore;

namespace ApbdCw7.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<PC> PCs { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<Component> Components { get; set; }
    public DbSet<PCComponent> PCComponents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PCComponent>()
            .HasKey(pc => new { pc.PCId, pc.ComponentCode });

        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer { Id = 1, Abbreviation = "AMD", FullName = "Advanced Micro Devices", FoundationDate = new DateTime(1969, 5, 1) },
            new ComponentManufacturer { Id = 2, Abbreviation = "NV", FullName = "NVIDIA Corporation", FoundationDate = new DateTime(1993, 4, 5) },
            new ComponentManufacturer { Id = 3, Abbreviation = "ASUS", FullName = "ASUSTeK Computer Inc.", FoundationDate = new DateTime(1989, 4, 2) }
        );

        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType { Id = 1, Abbreviation = "CPU", Name = "Processor" },
            new ComponentType { Id = 2, Abbreviation = "GPU", Name = "Graphics Card" },
            new ComponentType { Id = 3, Abbreviation = "MOBO", Name = "Motherboard" }
        );

        modelBuilder.Entity<Component>().HasData(
            new Component { Code = "CPU0000001", Name = "Ryzen 7 7800X3D", Description = "Gaming processor", ComponentManufacturersId = 1, ComponentTypesId = 1 },
            new Component { Code = "GPU0000001", Name = "RTX 4080 Super", Description = "High-end graphics card", ComponentManufacturersId = 2, ComponentTypesId = 2 },
            new Component { Code = "MOB0000001", Name = "ROG Crosshair X670E", Description = "Gaming motherboard", ComponentManufacturersId = 3, ComponentTypesId = 3 }
        );

        modelBuilder.Entity<PC>().HasData(
            new PC { Id = 1, Name = "Gaming Beast X", Weight = 12.5, Warranty = 36, CreatedAt = DateTime.Parse("2026-05-08T09:00:00"), Stock = 5 },
            new PC { Id = 2, Name = "Office Mini Pro", Weight = 4.2, Warranty = 24, CreatedAt = DateTime.Parse("2026-04-15T13:30:00"), Stock = 12 },
            new PC { Id = 3, Name = "Creator Workstation", Weight = 15.0, Warranty = 48, CreatedAt = DateTime.Parse("2026-05-10T10:00:00"), Stock = 2 }
        );

        modelBuilder.Entity<PCComponent>().HasData(
            new PCComponent { PCId = 1, ComponentCode = "CPU0000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "GPU0000001", Amount = 1 },
            new PCComponent { PCId = 1, ComponentCode = "MOB0000001", Amount = 1 },
            new PCComponent { PCId = 3, ComponentCode = "CPU0000001", Amount = 1 }
        );
    }
}