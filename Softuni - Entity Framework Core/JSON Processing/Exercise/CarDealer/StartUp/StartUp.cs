using CarDealer.Data;
using CarDealer.DTOs;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            //var json = File.ReadAllText("../../../Datasets/sales.json");
            var context = new CarDealerContext();
            Console.WriteLine(GetSalesWithAppliedDiscount(context));
        }
        // --09.
        public static string ImportSuppliers(CarDealerContext context,
            string inputJson)
        {
            var suppliers = JsonConvert
                .DeserializeObject<Supplier[]>(inputJson);

            context.Suppliers.AddRange(suppliers);
            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}.";
        }

        // --10.
        public static string ImportParts(CarDealerContext context,
            string inputJson)
        {
            var supliers = context.Suppliers
                .Select(x => x.Id)
                .ToList();

            var parts = JsonConvert
                .DeserializeObject<Part[]>(inputJson)
                .Where(x => supliers.Contains(x.SupplierId))
                .ToArray();

            context.Parts.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {parts.Length}.";
        }

        // --11.
        public static string ImportCars(CarDealerContext context,
            string inputJson)
        {
            var carsDTO = JsonConvert
                  .DeserializeObject<CarDTO[]>(inputJson);

            List<Car> cars = new List<Car>();
            List<PartCar> parts = new List<PartCar>();

            foreach (var carDTO in carsDTO)
            {
                var car = new Car()
                {
                    Make = carDTO.Make,
                    Model = carDTO.Model,
                    TraveledDistance = carDTO.TraveledDistance
                };

                cars.Add(car);

                foreach (var partDTO in carDTO.PartsId.Distinct())
                {
                    if (parts.Find(x => x.PartId == partDTO && x.Car == car)
                        == null)
                    {
                        var carPart = new PartCar()
                        {
                            PartId = partDTO,
                            Car = car
                        };

                        parts.Add(carPart);
                        car.PartsCars.Add(carPart);
                    }
                }
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(parts);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}.";
        }

        // --12.
        public static string ImportCustomers(CarDealerContext context,
            string inputJson)
        {
            var customers =
                JsonConvert
                .DeserializeObject<Customer[]>(inputJson);

            context.Customers.AddRange(customers);
            context.SaveChanges();

            return $"Successfully imported {customers.Length}.";
        }

        // --13.
        public static string ImportSales(CarDealerContext context,
            string inputJson)
        {
            var sales = JsonConvert.DeserializeObject<Sale[]>(inputJson);

            context.Sales.AddRange(sales);
            context.SaveChanges();

            return $"Successfully imported {sales.Length}.";
        }

        // --14.
        public static string GetOrderedCustomers(CarDealerContext context)
        {
            var customers = context
                .Customers
                .OrderBy(x => x.BirthDate)
                .ThenBy(x => x.IsYoungDriver)
                .Select(x => new
                {
                    Name = x.Name,
                    BirthDate = x.BirthDate.ToString("dd/MM/yyyy"),
                    IsYoungDriver = x.IsYoungDriver
                })
                .ToList();

            var json = JsonConvert.SerializeObject(customers);

            return json;
        }

        // --15.
        public static string GetCarsFromMakeToyota(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.Make == "Toyota")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .Select(x => new
                {
                    x.Id,
                    x.Make,
                    x.Model,
                    x.TraveledDistance
                })
                .ToList();

            var json = JsonConvert.SerializeObject(cars);

            return json;
        }

        // --16.
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new
                {
                    x.Id,
                    x.Name,
                    PartsCount = x.Parts.Count
                })
                .ToList();

            var json = JsonConvert.SerializeObject(suppliers);

            return json;
        }

        // --17.
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Include(x => x.PartsCars)
                .ThenInclude(x => x.Part)
                .Select(x => new
                {
                    car = new
                    {
                        Make = x.Make,
                        Model = x.Model,
                        TraveledDistance = x.TraveledDistance
                    },
                    parts = x.PartsCars
                    .Select(y => new
                    {
                        Name = y.Part.Name,
                        Price = $"{y.Part.Price:f2}"
                    })
                });

            var json = JsonConvert.SerializeObject(cars);

            return json;
        }

        // --18.
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            /*var customersNotOrdered = context
                .Customers
                .Include(x => x.Sales)
                .ThenInclude(x => x.Car)
                .ThenInclude(x => x.PartsCars)
                .ThenInclude(x => x.Part)
                .Where(x => x.Sales.Count >= 1)
                .Select(x => new
                {
                    fullName = x.Name,
                    boughtCars = x.Sales.Count,
                    sales = x.Sales
                })
                .ToList();

            var output = new List<CustomerDTO>();

            foreach (var customer in customersNotOrdered)
            {
                decimal money = 0.0M;
                foreach (var sale in customer.sales)
                {
                    var car = sale.Car;
                    foreach (var kvp in car.PartsCars)
                    {
                        money += kvp.Part.Price;
                    }
                }

                var currCustomer = new CustomerDTO
                {
                    fullName = customer.fullName,
                    boughtCars = customer.boughtCars,
                    spentMoney = (double)money
                };

                output.Add(currCustomer);
            }

            var customers = output
                .OrderByDescending(x => x.spentMoney)
                .ThenByDescending(x => x.boughtCars)
                .ToList();

            var json = JsonConvert.SerializeObject(customers,
                Formatting.Indented);

            return json;
            */

            var customers = context.Customers
                 .Include(c => c.Sales)
                 .ThenInclude(s => s.Car)
                 .ThenInclude(c => c.PartsCars)
                 .ThenInclude(pc => pc.Part)
                 .Where(c => c.Sales.Count >= 1)
                 .Select(x => new
                 {
                     FullName = x.Name,
                     BoughtCars = x.Sales.Count,
                     SpentMoney = x.Sales.Sum(y => y.Car.PartsCars.Sum(z => z.Part.Price))
                 })
                 .ToList()
                 .OrderByDescending(a => a.SpentMoney)
                 .ThenBy(a => a.BoughtCars)
                 .ToList();


            var json = JsonConvert.SerializeObject(customers, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                ContractResolver = new DefaultContractResolver()
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            });

            return json;
        }

        // --19.
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            /* var sales = context
              .Sales
              .Take(10)
              .Select(x => new SaleDTO
              {
                  car = new CarDTO2()
                  {
                      Make = x.Car.Make,
                      Model = x.Car.Model,
                      TraveledDistance = x.Car.TraveledDistance
                  },
                  customerName = x.Customer.Name,
                  discount = x.Discount.ToString(),
                  price = x.Car.PartsCars.Sum(x => x.Part.Price).ToString(),
                  priceWithDiscount = (x.Car.PartsCars.Sum(d => d.Part.Price) - x.Car.PartsCars.Sum(d => d.Part.Price) * (x.Discount/100)).ToString()
              })
              .ToList();

          var json = JsonConvert.SerializeObject(sales, Formatting.Indented);

          return json.Trim();
          */
            var sales = context.Sales
           .Take(10)
           .Select(s => new
           {
               car = new
               {
                   Make = s.Car.Make,
                   Model = s.Car.Model,
                   TraveledDistance = s.Car.TraveledDistance
               },
               customerName = s.Customer.Name,
               discount = s.Discount.ToString("0.00"),
               price = s.Car.PartsCars.Sum(p => p.Part.Price).ToString("0.00"),
               priceWithDiscount = (s.Car.PartsCars.Sum(p => p.Part.Price) * (1 - (s.Discount / 100))).ToString("0.00")
           })
           .AsNoTracking()
           .ToArray();

            return JsonConvert.SerializeObject(sales, Formatting.Indented);
        }

    }
}