using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            var context = new ProductShopContext();
            Console.WriteLine(GetUsersWithProducts(context));
        }


        // --01.
        public static string ImportUsers(ProductShopContext context,
            string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(UserDTO[]),
                new XmlRootAttribute("Users"));

            var usersDTOs = (UserDTO[])serializer
                .Deserialize(new StringReader(inputXml));

            var users = usersDTOs.Select(x => new User
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Age = x.Age
            }).ToArray();

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }

        // --02.
        public static string ImportProducts(ProductShopContext context,
            string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProductDTO[]),
               new XmlRootAttribute("Products"));

            var productDTOs = (ProductDTO[])serializer
                .Deserialize(new StringReader(inputXml));

            var products = productDTOs.Select(x => new Product()
            {
                Name = x.Name,
                Price = x.Price,
                SellerId = x.SellerId,
                BuyerId = x.BuyerId
            }).ToArray();

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        // --03.
        public static string ImportCategories(ProductShopContext context,
            string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(CategoryDTO[]),
               new XmlRootAttribute("Categories"));

            var categoryDTOs = (CategoryDTO[])serializer
                .Deserialize(new StringReader(inputXml));

            var categories = categoryDTOs.Select(x => new Category()
            {
                Name = x.Name
            })
            .Where(x => x.Name != null)
            .ToArray();

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Length}";
        }

        // --04.
        public static string ImportCategoryProducts(ProductShopContext context,
            string inputXml)
        {
            XmlSerializer serializer = new XmlSerializer(
                typeof(CategoryProductDTO[]),
              new XmlRootAttribute("CategoryProducts"));

            var categoryProductDTOs = (CategoryProductDTO[])serializer
                .Deserialize(new StringReader(inputXml));

            var categoriesProducts = categoryProductDTOs.Select(x =>
            new CategoryProduct()
            {
                CategoryId = x.CategoryId,
                ProductId = x.ProductId,
                Category = context
                .Categories
                .FirstOrDefault(c => c.Id == x.CategoryId),
                Product = context
                .Products
                .FirstOrDefault(c => c.Id == x.ProductId)
            })
            .Where(x => x.Category != default &&
            x.Product != default)
            .ToArray();

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }

        // --05.
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context
                .Products
                .Include(x => x.Buyer)
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new ProductDTOExport()
                {
                    Name = x.Name,
                    Price = (double)x.Price,
                    BuyerName = x.Buyer.FirstName + " " + x.Buyer.LastName
                })
                .Take(10)
                .ToArray();

            return ReturnXml(products, "Products");
        }

        // --06.
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context
                .Users
                .Where(x => x.ProductsSold.Any())
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new UserDTOExport()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    SoldProducts = x.ProductsSold
                    .Select(p => new ProductDTOExport2()
                    {
                        Name = p.Name,
                        Price = (double)p.Price
                    }).ToArray()
                })
                .Take(5)
                .ToArray();

            return ReturnXml(users, "Users");
        }

        // --07.
        public static string GetCategoriesByProductsCount(ProductShopContext
            context)
        {
            var categories = context
                .Categories
                .Select(x => new CategoryDTOExport()
                {
                    Name = x.Name,
                    ProductsCount = x.CategoryProducts.Count,
                    AveragePrice = x.CategoryProducts.Average(x => x.Product.Price),
                    TotalRevenue = x.CategoryProducts.Sum(x => x.Product.Price)
                })
                .OrderByDescending(x => x.ProductsCount)
                .ThenBy(x => x.TotalRevenue)
                .ToArray();

            return ReturnXml(categories, "Categories");
        }

        // --08.
        public static string GetUsersWithProducts(ProductShopContext
            context)
        {
            var xmlDocument = new XDocument();
            
            var usersCount = context
                .Users
                .Where(x => x.ProductsSold.Count >= 1)
                .Count();

            var users = context
                .Users
                .Where(x => x.ProductsSold.Count >= 1)
                .Select(x => new UserDTOExport2()
                {
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Age = x.Age,
                    SoldProducts = new SoldProductsDTOExport()
                    {
                        Count = x.ProductsSold.Count,
                        Products = x.ProductsSold
                        .Select(p => new ProductDTOExport2()
                        {
                            Name = p.Name,
                            Price = (double)p.Price
                        })
                        .OrderByDescending(x => x.Price)
                        .ToArray()
                    }
                })
                .OrderByDescending(x => x.SoldProducts.Count)
                .Take(10)
                .ToArray();

            var root = new XElement("Users");
            var xElementCount = new XElement("count", usersCount);
            var xElementUsers = new XElement("users");
            foreach (var user in users)
            {
                var xElement = new XElement("User");
                xElementUsers.Add(user.ToXElement());
            }
            root.Add(xElementCount);
            root.Add(xElementUsers);
            xmlDocument.Add(root);
            return xmlDocument.ToString();
        }

        private static string ReturnXml<T>(
            T[] collection, params string[] attribute)
        {
            var serializer = new XmlSerializer(
               typeof(T[]), new XmlRootAttribute(attribute[0]));

            var xml = new StringBuilder();

            var namespaces = new XmlSerializerNamespaces();

            namespaces.Add(string.Empty, string.Empty);

            serializer.Serialize(new StringWriter(xml), collection, namespaces);

            return xml.ToString().Trim();
        }

    }
}