using Spectre.Console;
using System.Linq;

namespace LibraryManagementSystem.m1chael888
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var menuChoices = new string[4] { "View Books", "Add Book", "Delete Book", "Close app" };
            var books = new List<string>()
            {
                "The Great Gatsby", "To Kill a Mockingbird", "1984", "Pride and Prejudice", "The Catcher in the Rye", "The Hobbit", "Moby-Dick", "War and Peace", "The Odyssey", "The Lord of the Rings", "Jane Eyre", "Animal Farm", "Brave New World", "The Chronicles of Narnia", "The Diary of a Young Girl", "The Alchemist", "Wuthering Heights", "Fahrenheit 451", "Catch-22", "The Hitchhiker's Guide to the Galaxy"
            };

            while (true)
            {
                Console.Clear();

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("[blue]What do you want to do next?[/]")
                    .AddChoices(menuChoices)
                    .WrapAround(true));

                switch (choice)
                {
                    case "View Books":
                        AnsiConsole.MarkupLine("[blue]List of Books:[/]\n");

                        foreach (var b in books)
                        {
                            AnsiConsole.MarkupLine($"[blue]-[/] {b}");
                        }

                        AnsiConsole.MarkupLine("\nPress any key to return to menu...");
                        Console.ReadKey();
                        break;
                    case "Add Book":
                        var title = AnsiConsole.Ask<string>("[blue]Enter the [white]title[/] of the book you want to add:[/]");

                        if (books.Contains(title))
                        {
                            AnsiConsole.MarkupLine("\n[red]That book already exists![/] =(");
                        }
                        else
                        {
                            books.Add(title);
                            AnsiConsole.MarkupLine("\n[green]Your book has been added![/] =)");
                        }

                        AnsiConsole.MarkupLine("\nPress any key to return to menu...");
                        Console.ReadKey();
                        break;
                    case "Delete Book":
                        if (books.Count() == 0)
                        {
                            AnsiConsole.MarkupLine("[red]There are no books to delete![/]");

                            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
                            Console.ReadKey();
                        }

                        var bookToDelete = AnsiConsole.Prompt(
                            new SelectionPrompt<string>()
                            .Title("[blue]Select a book to delete[/]")
                            .AddChoices(books)
                            .WrapAround(true)
                            .PageSize(25));
                            
                        if (books.Remove(bookToDelete))
                        {
                            AnsiConsole.MarkupLine("[green]Book successfuly deleted![/] =)");
                        }
                        else
                        {
                            AnsiConsole.MarkupLine("[red]Book not found![/] =(");
                        }

                        AnsiConsole.MarkupLine("\nPress any key to return to menu...");
                        Console.ReadKey();
                        break;
                    case "Close app":
                        AnsiConsole.MarkupLine("[blue]Goodbye[/] o/");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
} 
