using ProductShop.Data;
using ProductShop.Models;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {

        }

        // --01.
        public static string ImportUsers(ProductShopContext context, 
            string inputJson)
        {
            User[]? users = 
                JsonConvert.DeserializeObject<User[]>(inputJson);

            if (users != null)
            {
                context.Users.AddRange(users);
                context.SaveChanges();
            }

            return $"Successfully imported {users?.Length}";
        }

        // --02.
        public static string ImportProducts(ProductShopContext context, 
            string inputJson)
        {
            Product[]? products =
                JsonConvert.DeserializeObject<Product[]>(inputJson);

            if (products != null)
            {
                context.Products.AddRange(products);
                context.SaveChanges();
            }

            return $"Successfully imported {products?.Length}";
        }

        // --03.
        public static string ImportCategories(ProductShopContext context, 
            string inputJson)
        {
            Category[]? categories =
                JsonConvert.DeserializeObject<Category[]>(inputJson)
                .Where(x => x.Name != null)
                .ToArray();

            if (categories != null)
            {
                context.Categories.AddRange(categories);
                context.SaveChanges();
            }

            return $"Successfully imported {categories.Length}";
        }

        // --04.
        public static string ImportCategoryProducts(ProductShopContext context, 
            string inputJson)
        {
            CategoryProduct[]? categoriesProducts =
                JsonConvert.DeserializeObject<CategoryProduct[]>(inputJson);

            if (categoriesProducts != null)
            {
                foreach (var item in categoriesProducts)
                {
                    context.CategoriesProducts.Add(item);
                    context.SaveChanges();
                }
                context.CategoriesProducts.AddRange(categoriesProducts);
                context.SaveChanges();
            }

            return $"Successfully imported {categoriesProducts?.Length}";
        }

        // --05.
        public static string GetProductsInRange(ProductShopContext context)
        {
            var products =
                context.Products
                .Include(x => x.Seller)
                .Where(x => x.Price >= 500 && x.Price <= 1000)
                .OrderBy(x => x.Price)
                .Select(x => new
                {
                    name = x.Name,
                    price = x.Price,
                    seller = x.Seller.FirstName + " " + x.Seller.LastName
                })
                .ToList();

            var json = JsonConvert.SerializeObject(products);

            return json;
        }

        // --06.
        public static string GetSoldProducts(ProductShopContext context)
        {
            var users =
                context.Users
                .Include(x => x.ProductsSold)
                .ThenInclude(x => x.Seller)
                .Where(x => x.ProductsSold
                .Where(x => x.BuyerId != null).Count() >= 1)
                .OrderBy(x => x.LastName)
                .ThenBy(x => x.FirstName)
                .Select(x => new
                {
                    firstName = x.FirstName,
                    lastName = x.LastName,
                    soldProducts = x.ProductsSold
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    })
                    .ToList()
                })
                .ToList();

            var json = JsonConvert.SerializeObject(users);

            return json;
        }

        // --07.
        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Include(x => x.CategoriesProducts)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.CategoriesProducts.Count)
                .Select(x => new
                {
                    category = x.Name,
                    productsCount = x.CategoriesProducts.Count,
                    averagePrice = $"{x.CategoriesProducts.Average(x => x.Product.Price):f2}",
                    totalRevenue = $"{x.CategoriesProducts.Sum(x => x.Product.Price):f2}"
                })
                .ToList();

            var json = JsonConvert.SerializeObject(categories);

            return json;
        }

        // --08.
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users =
               context.Users
               .Include(x => x.ProductsSold)
               .ThenInclude(x => x.Buyer)
               .Where(x => x.ProductsSold
               .Where(x => x.BuyerId != null).Count() >= 1)
               .Select(x => new
               {
                   firstName = x.FirstName,
                   lastName = x.LastName,
                   age = x.Age,
                   soldProducts = x.ProductsSold
                   .Where(x => x.BuyerId != null)
                   .Select(p => new
                   {
                       name = p.Name,
                       price = p.Price
                   })
               })
               .OrderByDescending(x => x.soldProducts.Count())
               .ToList();

            var output = new
            {
                usersCount = users.Count(),
                users = users.Select(x => new
                {
                    x.firstName,
                    x.lastName,
                    x.age,
                    soldProducts = new
                    {
                        count = x.soldProducts.Count(),
                        products = x.soldProducts
                    }
                })
            };

            var json = JsonConvert.SerializeObject(output, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            });

            return json;
        }

    }
}