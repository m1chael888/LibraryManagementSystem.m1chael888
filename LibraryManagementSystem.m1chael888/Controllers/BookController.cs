using Spectre.Console;
using LibraryManagementSystem.m1chael888.Models;

namespace LibraryManagementSystem.m1chael888.Controllers
{
    internal class BooksController : BaseController, IBaseController
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
                DisplayMessage("\nThat book already exists! =(", "red");
            }
            else
            {
                var newBook = new Book(MockDatabase.LibraryItems.Count + 1, title, author, category, location, pages);
                MockDatabase.LibraryItems.Add(newBook);
                DisplayMessage("\nYour book has been added! =)", "green");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        public void DeleteItem()
        {

            if (MockDatabase.LibraryItems.OfType<Book>().Count() == 0)
            {
                DisplayMessage("There are no books to delete!", "red");

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
                DisplayMessage("Book successfuly deleted! =)", "green");
            }
            else
            {
                DisplayMessage("[red]Book not found! =(", "red");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
