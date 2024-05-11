using System;
using System.Collections.Generic;
using System.Linq;

namespace lab_2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new BookStoreContext())
            {
               

                while (true)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Show All Authors");
                    Console.WriteLine("2. Show All Books");
                    Console.WriteLine("3. Show All Customers");
                    Console.WriteLine("4. Show All Genres");
                    Console.WriteLine("5. Show All Publishers");
                    Console.WriteLine("6. Show All Reviews");
                    Console.WriteLine("7. Show All Tables");
                    Console.WriteLine("8. Exit");

                    Console.Write("Choose option: ");
                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            ShowAuthors();
                            break;
                        case "2":
                            ShowBooks();
                            break;
                        case "3":
                            ShowCustomers();
                            break;
                        case "4":
                            ShowGenres();
                            break;
                        case "5":
                            ShowPublishers();
                            break;
                        case "6":
                            ShowReviews();
                            break;
                        case "7":
                            ShowAllTables();
                            break;
                        case "8":
                            Console.WriteLine("Program has finished.");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Try again.");
                            break;
                    }
                }
            }

        }
        static void ShowAuthors()
        {
            using (var context = new BookStoreContext())
            {
                var authors = context.Authors.ToList();
                Console.WriteLine("Authors:");
                foreach (var author in authors)
                {
                    Console.WriteLine($"ID: {author.Id}, Name: {author.Name}");
                }
            }
        }

        static void ShowBooks()
        {
            using (var context = new BookStoreContext())
            {
                var books = context.Books.Include("Author").Include("Publisher").Include("Genre").ToList();
                Console.WriteLine("Books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Name: {book.Name}, Author: {book.Author.Name}, Publisher: {book.Publisher.Name}");
                }
            }
        }
        static void ShowCustomers()
        {
            using (var context = new BookStoreContext())
            {
                var customers = context.Customers.ToList();
                Console.WriteLine("Customers:");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}, Country: {customer.Country}, City: {customer.City}, Address: {customer.Address}");
                }
            }
        }

        static void ShowGenres()
        {
            using (var context = new BookStoreContext())
            {
                var genres = context.Genres.ToList();
                Console.WriteLine("Genres:");
                foreach (var genre in genres)
                {
                    Console.WriteLine($"ID: {genre.Id}, Name: {genre.Name}, Description: {genre.Description}");
                }
            }
        }

        static void ShowPublishers()
        {
            using (var context = new BookStoreContext())
            {
                var publishers = context.Publishers.ToList();
                Console.WriteLine("Publishers:");
                foreach (var publisher in publishers)
                {
                    Console.WriteLine($"ID: {publisher.Id}, Name: {publisher.Name}, Country: {publisher.Country}");
                }
            }
        }

        static void ShowReviews()
        {
            using (var context = new BookStoreContext())
            {
                var reviews = context.Reviews.ToList();
                Console.WriteLine("Reviews:");
                foreach(var review in reviews)
                {
                    Console.WriteLine($"ID: {review.Id}, BookId = {review.BookId}, CustomerId = {review.CustomerId}, Review = {review.CustomerId}, Date = {review.Date}");
                }
            }
        }
        static void ShowAllTables()
        {
            using(var context = new BookStoreContext())
            {
                Console.WriteLine("All Tables:");

                var authors = context.Authors.ToList();
                Console.WriteLine("Authors:");
                foreach (var author in authors)
                {
                    Console.WriteLine($"ID: {author.Id}, Name: {author.Name}");
                }

                var books = context.Books.Include("Author").Include("Publisher").Include("Genre").ToList();
                Console.WriteLine("Books:");
                foreach (var book in books)
                {
                    Console.WriteLine($"ID: {book.Id}, Name: {book.Name}, Author: {book.Author.Name}, Publisher: {book.Publisher.Name}");
                }

                var customers = context.Customers.ToList();
                Console.WriteLine("Customers:");
                foreach (var customer in customers)
                {
                    Console.WriteLine($"ID: {customer.Id}, Name: {customer.Name}, Email: {customer.Email}, Country: {customer.Country}, City: {customer.City}, Address: {customer.Address}");
                }

                var genres = context.Genres.ToList();
                Console.WriteLine("Genres:");
                foreach (var genre in genres)
                {
                    Console.WriteLine($"ID: {genre.Id}, Name: {genre.Name}, Description: {genre.Description}");
                }

                var publishers = context.Publishers.ToList();
                Console.WriteLine("Publishers:");
                foreach (var publisher in publishers)
                {
                    Console.WriteLine($"ID: {publisher.Id}, Name: {publisher.Name}, Country: {publisher.Country}");
                }

                var reviews = context.Reviews.ToList();
                Console.WriteLine("Reviews:");
                foreach (var review in reviews)
                {
                    Console.WriteLine($"ID: {review.Id}, BookId = {review.BookId}, CustomerId = {review.CustomerId}, Review = {review.CustomerId}, Date = {review.Date}");
                }
            }
        }
    }
}

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}

public class Genre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
} 

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int AuthorId { get; set; }
    public int PublisherId { get; set; } 
    public int GenreId { get; set; }
    public string Isbn { get; set; }
    public string Description { get; set; }

    public virtual Author Author { get; set; }
    public virtual Publisher Publisher { get; set; }
    public virtual Genre Genre { get; set; }
    public virtual ICollection<Review> Reviews { get; set; }
}

public class Review
{
    public int Id { get; set; }
    public int BookId { get; set; }
    public int CustomerId { get; set; }
    public string ReviewText { get; set; }
    public DateTime Date { get; set; }
    public virtual Book Book { get; set; }
    public virtual Customer Customer { get; set; }
}

