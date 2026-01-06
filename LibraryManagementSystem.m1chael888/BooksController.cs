using Spectre.Console;

namespace LibraryManagementSystem.m1chael888
{
    internal class BooksController
    {
        internal static class MockDatabase
        {
            internal static List<string> Books = new()
            {
            "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm", "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist", "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"
            };
        }

        internal void ViewBooks()
        {
            AnsiConsole.MarkupLine("[blue]List of Books:[/]\n");

            foreach (var b in MockDatabase.Books)
            {
                AnsiConsole.MarkupLine($"[blue]-[/] {b}");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        internal void AddBook()
        {
            var title = AnsiConsole.Ask<string>("[blue]Enter the [white]title[/] of the book you want to add:[/]");

            if (MockDatabase.Books.Contains(title))
            {
                AnsiConsole.MarkupLine("\n[red]That book already exists![/] =(");
            }
            else
            {
                MockDatabase.Books.Add(title);
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
                new SelectionPrompt<string>()
                .Title("[blue]Select a book to delete[/]")
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
