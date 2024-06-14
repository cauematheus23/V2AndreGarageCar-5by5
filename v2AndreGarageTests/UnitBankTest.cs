using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Models;
using V2AndreGarageCar_5by5.Controllers;
using V2AndreGarageCar_5by5.Data;
using v2AndreGarageTests.Services;

namespace v2AndreGarageTests
{
    public class UnitBankTest
    {
        private DbContextOptions<V2AndreGarageCar_5by5Context> _options;
        [Fact]
        //private void InitializeDatabase()
        //{
        //    _options = new DbContextOptionsBuilder<V2AndreGarageCar_5by5Context>()
        //        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        //        .Options;
        //    using (var context = new V2AndreGarageCar_5by5Context(_options))
        //    {
        //        context.Car.Add(new Models.Car { Plate = "ATB1010", Name = "Volvo", ModelYear = 1997, FabricationYear = 2005, Color = "Red" });
        //        context.Car.Add(new Models.Car { Plate = "ATB2020", Name = "Mitsubishi", ModelYear = 2010, FabricationYear = 2012, Color = "Black" });
        //        context.Car.Add(new Models.Car { Plate = "ATB3030", Name = "Porsche", ModelYear = 2020, FabricationYear = 2022, Color = "Green" });
        //        context.SaveChanges();
        //    }
        //}
        //[Fact]
        //private void TestGetAll()
        //{
        //    InitializeDatabase();
        //    using (var context = new V2AndreGarageCar_5by5Context(_options))
        //    {
        //        var service = new CarsController(context);
        //        var cars = service.GetCar().Result.Value;
        //        Assert.Equal(3, cars.Count());
        //    }
        //}

        //private void TestGetCar()
        //{
        //    InitializeDatabase();
        //    using (var context = new V2AndreGarageCar_5by5Context(_options))
        //    {
        //        var service = new CarsController(context);
        //        var car = service.GetCarByPlate("ATB1020").Result.Value;
        //        Assert.Equal("ATB1010", car.Plate);
        //    }
        //}

        private void TestPostBank()
        {
            for (int i = 0; i < 10000; i++)
            {
                var bank = new Bank { CNPJ = $"123{i}", Name = $"Bank {i}" };
                Bank bankout = new BankServiceTest().PostBanks(bank).Result;
            }
            Assert.True(true);
        }
    }
}