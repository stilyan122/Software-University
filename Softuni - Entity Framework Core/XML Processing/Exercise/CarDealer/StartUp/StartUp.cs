using CarDealer.Data;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
        }

        // --09.
        public static string ImportSuppliers(CarDealerContext context,
            string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SupplierDTO[]),
                new XmlRootAttribute("Suppliers"));

            var suppliersDTOs = (SupplierDTO[])serializer
                .Deserialize(new StringReader(inputXml));

            var suppliers = suppliersDTOs.Select(x => new Supplier
            {
                Name = x.Name,
                IsImporter = x.IsImporter
            }).ToArray();

            context.Suppliers.AddRange(suppliers);

            context.SaveChanges();

            return $"Successfully imported {suppliers.Length}";
        }

        // --10.
        public static string ImportParts(CarDealerContext context,
            string inputXml)
        {
            var serializer = new XmlSerializer(typeof(PartDTO[]),
                new XmlRootAttribute("Parts"));

            var partsDTOs = (PartDTO[])serializer
                .Deserialize(new StringReader(inputXml));

            var parts = partsDTOs
            .Where(p => context.Suppliers
            .FirstOrDefault(x => x.Id == p.SupplierId)
            != default(Supplier))
            .Select(x => new Part()
            {
                Name = x.Name,
                Price = x.Price,
                Quantity = x.Quantity,
                Supplier = context.Suppliers.FirstOrDefault(s => s.Id == x.SupplierId)
            })
            .ToArray();

            context.Parts.AddRange(parts);

            context.SaveChanges();

            return $"Successfully imported {parts.Length}";
        }

        // --11.
        public static string ImportCars(CarDealerContext context,
            string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CarImportDTO[]),
            new XmlRootAttribute("Cars"));

            var carDTOs =
                   (CarImportDTO[])(serializer
                   .Deserialize(new StringReader(inputXml)));

            int counter = 1;

            var cars = new List<Car>();
            var partsCars = new List<PartCar>();

            foreach (var DTO in carDTOs)
            {
                var partsDTO = DTO.Parts;
                var parts = new List<PartCar>();

                var car = new Car()
                {
                    Make = DTO.Make,
                    Model = DTO.Model,
                    TraveledDistance = DTO.TraveledDistance
                };

                foreach (var partDTO in partsDTO)
                {
                    var partToFind = context
                        .Parts
                        .FirstOrDefault(x => x.Id.ToString()
                        == partDTO.Id);

                    if (partToFind != default(Part))
                    {
                        var part = new PartCar()
                        {
                            CarId = counter,
                            PartId = partToFind.Id,
                            Car = car,
                            Part = partToFind
                        };

                        if (parts.Find(x => x.CarId == part.CarId &&
                            x.PartId == part.PartId) == null)
                        {
                            parts.Add(part);
                            partsCars.Add(part);
                        }
                    }
                }

                car.PartsCars = parts.Distinct().ToList();
                cars.Add(car);
                counter++;
            }

            context.Cars.AddRange(cars);
            context.PartsCars.AddRange(partsCars);
            context.SaveChanges();

            return $"Successfully imported {cars.Count}";
        }

        // --12.
        public static string ImportCustomers(CarDealerContext context,
            string inputXml)
        {
            var serializer = new XmlSerializer(typeof(CustomerDTO[]),
             new XmlRootAttribute("Customers"));

            var customersDTOs =
                   (CustomerDTO[])(serializer
                   .Deserialize(new StringReader(inputXml)));

            var customers = customersDTOs.Select(x => new Customer()
            {
                Name = x.Name,
                BirthDate = x.BirthDate,
                IsYoungDriver = x.IsYoungDriver
            }).ToArray();

            context.Customers.AddRange(customers);

            context.SaveChanges();

            return $"Successfully imported {customers.Length}";
        }

        // --13.
        public static string ImportSales(CarDealerContext context,
            string inputXml)
        {
            var serializer = new XmlSerializer(typeof(SaleDTO[]),
             new XmlRootAttribute("Sales"));

            var salesDTOs =
                   (SaleDTO[])(serializer
                   .Deserialize(new StringReader(inputXml)));

            var sales = salesDTOs.Select(x => new Sale()
            {
                CustomerId = x.CustomerId,
                Customer = context.Customers
                .FirstOrDefault(y => y.Id == x.CustomerId),
                CarId = x.CarId,
                Car = context.Cars
                .FirstOrDefault(y => y.Id == x.CarId),
                Discount = x.Discount
            })
           .Where(x => x.Car != default)
           .ToArray();

            context.Sales.AddRange(sales);

            context.SaveChanges();

            return $"Successfully imported {sales.Length}";
        }

        // --14.
        public static string GetCarsWithDistance(CarDealerContext context)
        {
            var cars = context.Cars
                .Where(x => x.TraveledDistance > 2000000)
                .OrderBy(x => x.Make)
                .ThenBy(x => x.Model)
                .Take(10)
                .Select(x => new CarDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance
                })
                .ToArray();

            var serializer = new XmlSerializer(typeof(CarDTO[]),
                new XmlRootAttribute("cars"));

            var xsn = new XmlSerializerNamespaces();

            xsn.Add(string.Empty, string.Empty);

            StringBuilder xml = new StringBuilder();

            serializer.Serialize(new StringWriter(xml), cars, xsn);

            return ReturnXML("cars", cars);
        }

        // --15.
        public static string GetCarsFromMakeBmw(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Where(x => x.Make == "BMW")
                .OrderBy(x => x.Model)
                .ThenByDescending(x => x.TraveledDistance)
                .Select(x => new CarDTO2
                {
                    Id = x.Id,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance
                })
                .ToArray();

            return ReturnXML("cars", cars);
        }

        // --16.
        public static string GetLocalSuppliers(CarDealerContext context)
        {
            var suppliers = context
                .Suppliers
                .Where(x => x.IsImporter == false)
                .Select(x => new SupplierDTO2
                {
                    Id = x.Id,
                    Name = x.Name,
                    Parts = x.Parts.Count
                })
                .ToArray();

            return ReturnXML("suppliers", suppliers);
        }

        // --17.
        public static string GetCarsWithTheirListOfParts(CarDealerContext context)
        {
            var cars = context
                .Cars
                .Include(x => x.PartsCars)
                .ThenInclude(x => x.Part)
                .Select(x => new CarPartDTO
                {
                    Make = x.Make,
                    Model = x.Model,
                    TraveledDistance = x.TraveledDistance,
                    Parts = x.PartsCars
                    .Select(x => x.Part)
                    .Select(x => new PartDTO2
                    {
                        Name = x.Name,
                        Price = x.Price
                    })
                    .OrderByDescending(x => x.Price)
                    .ToList()
                })
                .OrderByDescending(x => x.TraveledDistance)
                .ThenBy(x => x.Model)
                .Take(5)
                .ToArray();

            return ReturnXML("cars", cars);
        }

        // --18.
        public static string GetTotalSalesByCustomer(CarDealerContext context)
        {
            var customers = context.
                Customers
                .Include(x => x.Sales)
                .ThenInclude(x => x.Car)
                .ThenInclude(x => x.PartsCars)
                .ThenInclude(x => x.Part)
                .Where(x => x.Sales.Count >= 1)
                .ToList()
                .Select(x => new CustomerDTO2
                {
                    BoughtCars = x.Sales.Count,
                    FullName = x.Name,
                    TotalMoney = x.Sales.Sum(s =>
                        s.Car.PartsCars.Sum(pc =>
                            Math.Round(x.IsYoungDriver ? pc.Part.Price * 0.95m : pc.Part.Price, 2)
                    ))
                })
                .OrderByDescending(x => x.TotalMoney)
                .ToArray();

            return ReturnXML("customers", customers);
        }

        // --19.
        public static string GetSalesWithAppliedDiscount(CarDealerContext context)
        {
            var sales =
                context.Sales
                .Select(x => new SaleDTO2
                {
                    Car = new CarDTO3()
                    {
                        Make = x.Car.Make,
                        Model = x.Car.Model,
                        TraveledDistance = x.Car.TraveledDistance
                    },
                    Name = x.Customer.Name,
                    Discount = x.Discount,
                    Price = x.Car.PartsCars.Sum(x => x.Part.Price),
                    DiscountPrice = (decimal)Math.Round((double)(x.Car.PartsCars
                            .Sum(p => p.Part.Price) * (1 - (x.Discount / 100))), 4)
                })
                .ToArray();

            return ReturnXML("sales", sales);
        }

        private static string ReturnXML<T>(string root, T[] collection)
        {
            var serializer = new XmlSerializer(typeof(T[]),
               new XmlRootAttribute(root));

            var settings = new XmlSerializerNamespaces();

            settings.Add(string.Empty, string.Empty);

            var xml = new StringBuilder();

            serializer.Serialize(new StringWriter(xml), collection, settings);

            return xml.ToString().Trim();
        }
    }
}