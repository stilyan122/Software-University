namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.IdentityModel.Tokens;
    using System.Threading.Channels;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);
            Console.WriteLine(GetBooksByCategory(db,Console.ReadLine()));
        }

        //--02.
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new ();

            var books =
            context.Books
                .Where(x => x.AgeRestriction.ToString()
                .ToLower() == command.ToLower())
                .OrderBy(x => x.Title)
                .Select(x => new
                {
                    x.Title
                })
                .ToList();

            books.ForEach(book =>
            {
                sb.AppendLine(book.Title);
            });

            return sb.ToString().Trim();
        }

        //--03.
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new ();

            var books = context.Books
                .Where(x => x.EditionType.ToString() == "Gold"
                && x.Copies < 5000)
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title
                })
                .ToList();

            books.ForEach(book =>
            {
                sb.AppendLine(book.Title);
            });

            return sb.ToString().Trim();
        }

        //--04.
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new ();

            var books = context.Books
                .Where(x => x.Price > 40)
                .OrderByDescending(x => x.Price)
                .Select(x => new
                {
                    x.Title,
                    x.Price
                })
                .ToList();

            books.ForEach(book =>
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            });

            return sb.ToString().Trim();
        }

        //--05.
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new ();

            var books = context.Books
                .Where(x => x.ReleaseDate.Value.Year != year)
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title
                })
                .ToList();

            books.ForEach(book =>
            {
                sb.AppendLine(book.Title);
            });

            return sb.ToString().Trim();
        }

        //--06.
        public static string GetBooksByCategory(BookShopContext context, string input)
        {

            StringBuilder sb = new();

            List<string> categories = input.Split(" ",
                StringSplitOptions.RemoveEmptyEntries).ToList();

            bool ListContainsWord(string category)
            {
                foreach (var word in categories)
                {
                    if (word.ToLower() == category.ToLower())
                    {
                        return true;
                    }
                }
                return false;
            }
            
            var books = context.Books
                .Include(x => x.BookCategories)
                .SelectMany(x => x.BookCategories, (a, b) =>new
                {
                    Book = a,
                    Category = b.Category
                })
                .AsEnumerable()
                .Where(x => ListContainsWord(x.Category.Name))
                .OrderBy(x => x.Book.Title)
                .Select(x => new
                {
                    x.Book.Title,
                    x.Category.Name
                })
                .ToList();

            books.ForEach(book =>
            {
                sb.AppendLine(book.Title);
            });

            return sb.ToString().Trim();
        }

        //--07.
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            StringBuilder sb = new ();

            int year = int.Parse(date.Split("-")[2]);
            int month = int.Parse(date.Split("-")[1]);
            int day = int.Parse(date.Split("-")[0]);
           
            var books = context.Books
                .Where(x => x.ReleaseDate.Value.
                    CompareTo(new DateTime(year,month,day)) < 0)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.EditionType,
                    x.Price
                })
                .ToList();

            books.ForEach(book =>
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            });

            return sb.ToString().Trim();
        }

        //--08.
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new ();

            var authors = context.Authors
                .Where(x => x.FirstName.EndsWith(input))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName
                })
                .OrderBy(x => x.FirstName + " " + x.LastName)
                .ToList();

            authors.ForEach(author =>
            {
                sb.AppendLine($"{author.FirstName} {author.LastName}");
            });

            return sb.ToString().Trim();
        }

        //--09.
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new ();

            var books = context.Books
                .Where(x => x.Title.ToLower().Contains(input.ToLower()))
                .OrderBy(x => x.Title)
                .ToList();

            books.ForEach(book =>
            {
                sb.AppendLine(book.Title);
            });

            return sb.ToString().Trim();
        }

        //--10.
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new ();

            var books = context.Books
                .Include(x => x.Author)
                .Where(x => x.Author.LastName
                .ToLower().StartsWith(input.ToLower()))
                .OrderBy(x => x.BookId)
                .Select(x => new
                {
                    x.Title,
                    AuthorFirstName = x.Author.FirstName,
                    AuthorLastName = x.Author.LastName
                })
                .ToList();

            books.ForEach(book =>
            {
                sb.AppendLine($"{book.Title} ({book.AuthorFirstName} " +
                    $"{book.AuthorLastName})");
            });

            return sb.ToString().Trim();
        }

        //--11.
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            int count =
                context.Books
                .Where(x => x.Title.Length > lengthCheck)
                .ToList()
                .Count;

            return count;
        }

        //--12.
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new ();

            var authors = context.Authors
                .Include(x => x.Books)
                .OrderByDescending(x => x.Books.Sum(x => x.Copies))
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    Copies = x.Books.Sum(x => x.Copies)
                })
                .ToList();

            authors.ForEach(author =>
            {
                sb.AppendLine($"{author.FirstName} {author.LastName} - {author.Copies}");
            });

            return sb.ToString().Trim();
        }

        //--13.
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new ();

            var categories = context.Categories
                .Include(x => x.CategoryBooks)
                .OrderByDescending(x => x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies))
                .ThenBy(x => x.Name)
                .Select(x => new
                {
                    x.Name,
                    Profit = x.CategoryBooks.Sum(x => x.Book.Price * x.Book.Copies)
                })
                .ToList();

            categories.ForEach(category =>
            {
                sb.AppendLine($"{category.Name} ${category.Profit:f2}");
            });

            return sb.ToString().Trim();
        }

        //--14.
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new ();

            var categories =
                context.Categories
                .Include(x => x.CategoryBooks)
                .Select(x => new
                {
                    x.Name,
                    Books = x.CategoryBooks
                    .OrderByDescending(x => x.Book.ReleaseDate)
                    .Take(3)
                    .Select(y => new
                    {
                        Title = y.Book.Title,
                        Year = y.Book.ReleaseDate.Value.Year
                    })
                    .ToList()
                })
                .OrderBy(x => x.Name)
                .ToList();

            categories.ForEach(category =>
            {
                sb.AppendLine($"--{category.Name}");
                category.Books.ForEach(book =>
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                });
            });

            return sb.ToString().Trim();
        }

        //--15.
        public static void IncreasePrices(BookShopContext context)
        {
            context.Books
                .Where(x => x.ReleaseDate.Value.Year < 2010)
                .ToList()
                .ForEach(book =>
                {
                    book.Price += 5;
                });
            context.SaveChanges();
        }

        //--16.
        public static int RemoveBooks(BookShopContext context)
        {
            var books = context.Books
                .Where(x => x.Copies < 4200)
                .ToList();

            int count = books.Count;
            context.Books.RemoveRange(books);
            context.SaveChanges();

            return count;
        }
    }
}


