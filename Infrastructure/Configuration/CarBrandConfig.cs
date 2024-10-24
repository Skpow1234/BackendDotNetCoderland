using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Configuration;

public class CarBrandConfig : IEntityTypeConfiguration<CarBrand>
{
    public void Configure(EntityTypeBuilder<CarBrand> builder)
    {
        builder.ToTable(nameof(CarBrand));
        builder.HasKey(x => x.Id);
        builder.Property(p => p.State)
            .HasDefaultValue(true);
        builder.HasData(new List<CarBrand>()
        {
            new () {Name = "Chevrolet", Description = "It is a manufacturer of automobiles and trucks based in Detroit, Michigan, United States, as a division of General Motors.", BrandId = Guid.NewGuid()},
            new () {Name = "Mazda", Description = "It is a Japanese-origin firm founded in 1920 and headquartered in Hiroshima.", BrandId = Guid.NewGuid()},
            new () {Name = "Ford", Description = "It is a multinational automobile manufacturer of American origin.", BrandId = Guid.NewGuid()},
            new () {Name = "Toyota", Description = "A Japanese automotive manufacturer headquartered in Toyota City, Japan, known for reliable and fuel-efficient vehicles.", BrandId = Guid.NewGuid()},
            new () {Name = "BMW", Description = "A German multinational company which produces luxury vehicles and motorcycles.", BrandId = Guid.NewGuid()},
            new () {Name = "Honda", Description = "A Japanese public multinational conglomerate primarily known for manufacturing automobiles, motorcycles, and power equipment.", BrandId = Guid.NewGuid()},
            new () {Name = "Mercedes-Benz", Description = "A global German automobile manufacturer known for luxury vehicles, buses, coaches, and trucks.", BrandId = Guid.NewGuid()},
            new () {Name = "Volkswagen", Description = "A German automobile manufacturer and the largest automaker worldwide by sales.", BrandId = Guid.NewGuid()},
            new () {Name = "Hyundai", Description = "A South Korean multinational automotive manufacturer headquartered in Seoul.", BrandId = Guid.NewGuid()},
            new () {Name = "Nissan", Description = "A Japanese automobile manufacturer headquartered in Yokohama, Japan, known for producing a wide range of vehicles.", BrandId = Guid.NewGuid()},
            new () {Name = "Tesla", Description = "An American electric vehicle and clean energy company based in Palo Alto, California.", BrandId = Guid.NewGuid()},
            new () {Name = "Porsche", Description = "A German automobile manufacturer specializing in high-performance sports cars, SUVs, and sedans.", BrandId = Guid.NewGuid()},
            new () {Name = "Audi", Description = "A German automobile manufacturer that designs, engineers, produces, markets, and distributes luxury vehicles.", BrandId = Guid.NewGuid()}
        });
    }
}
