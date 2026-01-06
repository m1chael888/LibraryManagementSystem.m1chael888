using Spectre.Console;
using static LibraryManagementSystem.m1chael888.Models;

namespace LibraryManagementSystem.m1chael888
{
    internal class BooksController
    {
        internal static class MockDatabase
        {
            internal static List<LibraryItem> LibraryItems = new()
    {
            new Book(1, "The Great Gatsby", "F. Scott Fitzgerald", "Fiction", "A1", 218),
            new Book(2, "To Kill a Mockingbird", "Harper Lee", "Fiction", "A2", 324),
            new Book(3, "1984", "George Orwell", "Dystopian", "A3", 328),
            new Book(4, "Pride and Prejudice", "Jane Austen", "Romance", "A4", 279),
            new Book(5, "The Catcher in the Rye", "J.D. Salinger", "Fiction", "A5", 214),

            new Magazine(1, "National Geographic", "National Geographic Partners", new DateTime(2024, 8, 1), "B1", 12),
            new Magazine(2, "Time", "Time USA, LLC", new DateTime(2024, 7, 15), "B2", 8),
            new Magazine(3, "The Economist", "The Economist Group", new DateTime(2024, 6, 10), "B3", 16),
            new Magazine(4, "Forbes", "Forbes Media", new DateTime(2024, 5, 20), "B4", 10),
            new Magazine(5, "Wired", "Condé Nast", new DateTime(2024, 4, 5), "B5", 15),

            new Newspaper(1, "The New York Times", "The New York Times Company", new DateTime(2024, 8, 18), "C1"),
            new Newspaper(2, "The Guardian", "Guardian Media Group", new DateTime(2024, 8, 17), "C2"),
            new Newspaper(3, "The Washington Post", "Nash Holdings", new DateTime(2024, 8, 16), "C3"),
            new Newspaper(4, "The Wall Street Journal", "Dow Jones & Company", new DateTime(2024, 8, 15), "C4"),
            new Newspaper(5, "USA Today", "Gannett", new DateTime(2024, 8, 14), "C5")
    };
        }

        internal void ViewBooks()
        {
            var table = new Table();
            table.Border(TableBorder.Rounded);

            table.AddColumn("[blue]ID[/]");
            table.AddColumn("[blue]Title[/]");
            table.AddColumn("[blue]Author[/]");
            table.AddColumn("[blue]Category[/]");
            table.AddColumn("[blue]Location[/]");
            table.AddColumn("[blue]Pages[/]");

            var books = MockDatabase.LibraryItems.OfType<Book>();

            foreach (var b in books)
            {
                table.AddRow(
                    b.Id.ToString(),
                    $"[blue]{b.Name}[/]",
                    $"[blue]{b.Author}[/]",
                    $"[blue]{b.Category}[/]",
                    $"[blue]{b.Location}[/]",
                    b.Pages.ToString()
                    );
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        internal void AddBook()
        {
            var title = AnsiConsole.Ask<string>("[blue]Enter the [white]title[/] of the book you want to add:[/]");
            var author = AnsiConsole.Ask<string>("[blue]Enter the [white]author[/] of the book:[/]");
            var category = AnsiConsole.Ask<string>("[blue]Enter the [white]category[/] of the book:[/]");
            var location = AnsiConsole.Ask<string>("[blue]Enter the [white]location[/] of the book:[/]");
            var pages = AnsiConsole.Ask<int>("[blue]Enter the [white]page count[/] of the book you want to add:[/]");

            if (MockDatabase.LibraryItems.FirstOrDefault(x => x.Name.ToLower() == title.ToLower(), null) != null)
            {
                AnsiConsole.MarkupLine("\n[red]That book already exists![/] =(");
            }
            else
            {
                var newBook = new Book(MockDatabase.LibraryItems.Count + 1, title, author, category, location, pages);
                MockDatabase.LibraryItems.Add(newBook);
                AnsiConsole.MarkupLine("\n[green]Your book has been added![/] =)");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        internal void DeleteBook()
        {

            if (MockDatabase.LibraryItems.OfType<Book>().Count() == 0)
            {
                AnsiConsole.MarkupLine("[red]There are no books to delete![/]");

                AnsiConsole.MarkupLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            var bookToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<Book>()
                .Title("[blue]Select a book to delete[/]")
                .UseConverter(b => $"{b.Name}")
                .AddChoices(MockDatabase.LibraryItems.OfType<Book>())
                .WrapAround(true)
                .PageSize(25));

            if (MockDatabase.LibraryItems.Remove(bookToDelete))
            {
                AnsiConsole.MarkupLine("[green]Book successfuly deleted![/] =)");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Book not found![/] =(");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
