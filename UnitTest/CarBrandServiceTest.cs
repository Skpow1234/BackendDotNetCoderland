using Application.Services;
using Domain.Entities;
using Domain.Ports;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shared.Common;

namespace UnitTest;

public class CarBrandServiceTest
{
    private readonly CarBrandService _brandService;
    private readonly Mock<ICarBrandRepository> _brandRepositoryMock;
    public CarBrandServiceTest()
    {
        _brandRepositoryMock = new Mock<ICarBrandRepository>();
        _brandService = new CarBrandService(_brandRepositoryMock.Object);
    }

    private ApiContext GetInMemoryContext()
    {
        var options = new DbContextOptionsBuilder<ApiContext>()
            .UseInMemoryDatabase(databaseName: "dbautos")
            .Options;
        var context = new ApiContext(options);
        context.CarBrand.AddRange(
            new CarBrand { Id = 1, Name = "Chevrolet" },
            new CarBrand { Id = 2, Name = "Mazda" },
            new CarBrand { Id = 3, Name = "Ford" },
            new CarBrand { Id = 4, Name = "Toyota" },
            new CarBrand { Id = 5, Name = "BMW" },
            new CarBrand { Id = 6, Name = "Honda" },
            new CarBrand { Id = 7, Name = "Mercedes-Benz" },
            new CarBrand { Id = 8, Name = "Volkswagen" },
            new CarBrand { Id = 9, Name = "Hyundai" },
            new CarBrand { Id = 10, Name = "Nissan" },
            new CarBrand { Id = 11, Name = "Tesla" },
            new CarBrand { Id = 12, Name = "Porsche" },
            new CarBrand { Id = 13, Name = "Audi" }
        );
        context.SaveChanges();
        return context;
    }
    [Fact]
    public async Task GetBrandAsync_Success()
    {
        var dbContext = GetInMemoryContext();
        var result = await _brandService.GetBrandsAsync();
        var actionResult = Assert.IsAssignableFrom<IEnumerable<CarBrand>>(result);
        var returnValue = Assert.IsType<List<CarBrand>>(actionResult);

        Assert.Equal(13, returnValue.Count);
        Assert.Contains(returnValue, cb => cb.Name == "Chevrolet");
        Assert.Contains(returnValue, cb => cb.Name == "Mazda");
        Assert.Contains(returnValue, cb => cb.Name == "Ford");
        Assert.Contains(returnValue, cb => cb.Name == "Toyota");
        Assert.Contains(returnValue, cb => cb.Name == "BMW");
        Assert.Contains(returnValue, cb => cb.Name == "Honda");
        Assert.Contains(returnValue, cb => cb.Name == "Mercedes-Benz");
        Assert.Contains(returnValue, cb => cb.Name == "Volkswagen");
        Assert.Contains(returnValue, cb => cb.Name == "Hyundai");
        Assert.Contains(returnValue, cb => cb.Name == "Nissan");
        Assert.Contains(returnValue, cb => cb.Name == "Tesla");
        Assert.Contains(returnValue, cb => cb.Name == "Porsche");
        Assert.Contains(returnValue, cb => cb.Name == "Audi");
    }

    [Fact]
    public async Task GetBrandAsync_NoRecords()
    {
        _brandRepositoryMock.Setup(repo => repo.GetAllBrandsAsync())
        .ReturnsAsync(new List<CarBrand>());
        var result = await _brandService.GetBrandsAsync();
        Assert.Equal(Result.NoRecords, result.Result);
        Assert.Equal("No records currently exist.", result.Message);
        Assert.Null(result.BrandList);
    }
}
