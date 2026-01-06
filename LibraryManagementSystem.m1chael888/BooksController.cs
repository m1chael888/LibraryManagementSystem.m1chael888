using Spectre.Console;

namespace LibraryManagementSystem.m1chael888
{
    internal class BooksController
    {
        internal static class MockDatabase
        {
            internal static List<Book> Books = new()
            {
            new Book("The Great Gatsby", 180),
            new Book("To Kill a Mockingbird", 281),
            new Book("1984", 328),
            new Book("Pride and Prejudice", 432),
            new Book("The Catcher in the Rye", 277),
            new Book("The Hobbit", 310),
            new Book("Moby-Dick", 585),
            new Book("War and Peace", 1225),
            new Book("The Odyssey", 400),
            new Book("The Lord of the Rings", 1178),
            new Book("Jane Eyre", 500),
            new Book("Animal Farm", 112),
            new Book("Brave New World", 268),
            new Book("The Chronicles of Narnia", 768),
            new Book("The Diary of a Young Girl", 283),
            new Book("The Alchemist", 208),
            new Book("Wuthering Heights", 400),
            new Book("Fahrenheit 451", 158),
            new Book("Catch-22", 453),
            new Book("The Hitchhiker's Guide to the Galaxy", 224)
            };
        }

        internal void ViewBooks()
        {
            AnsiConsole.MarkupLine("[blue]List of Books:[/]\n");

            foreach (var b in MockDatabase.Books)
            {
                AnsiConsole.MarkupLine($"[blue]-[/] {b.Name} [grey]- {b.Pages} pages[/]");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        internal void AddBook()
        {
            var title = AnsiConsole.Ask<string>("[blue]Enter the [white]title[/] of the book you want to add:[/]");
            var pages = AnsiConsole.Ask<int>("[blue]Enter the [white]page count[/] of the book you want to add:[/]");

            if (MockDatabase.Books.FirstOrDefault(x => x.Name.ToLower() == title.ToLower(), null) != null)
            {
                AnsiConsole.MarkupLine("\n[red]That book already exists![/] =(");
            }
            else
            {
                var newBook = new Book(title, pages);
                MockDatabase.Books.Add(newBook);
                AnsiConsole.MarkupLine("\n[green]Your book has been added![/] =)");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        internal void DeleteBook()
        {
            if (MockDatabase.Books.Count() == 0)
            {
                AnsiConsole.MarkupLine("[red]There are no books to delete![/]");

                AnsiConsole.MarkupLine("\nPress any key to return to menu...");
                Console.ReadKey();
            }

            var bookToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<Book>()
                .Title("[blue]Select a book to delete[/]")
                .UseConverter(b => $"{b.Name}")
                .AddChoices(MockDatabase.Books)
                .WrapAround(true)
                .PageSize(25));

            if (MockDatabase.Books.Remove(bookToDelete))
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
