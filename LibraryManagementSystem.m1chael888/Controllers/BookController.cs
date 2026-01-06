using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;
using static LibraryManagementSystem.m1chael888.Models;

namespace LibraryManagementSystem.m1chael888.Controllers
{
    internal class BooksController : BaseController
    {
        public void ViewItems()
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
                    b.Name,
                    b.Author,
                    b.Category,
                    b.Location,
                    b.Pages.ToString()
                    );
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        public void AddItem()
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

        public void DeleteItem()
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
