using Spectre.Console;
using LibraryManagementSystem.m1chael888.Models;

namespace LibraryManagementSystem.m1chael888.Controllers
{
    internal class NewspaperController : BaseController
    {
        public void ViewItems()
        {
            var table = new Table();

            table.Border(TableBorder.Rounded);
            table.AddColumn("[blue]ID[/]");
            table.AddColumn("[blue]Title[/]");
            table.AddColumn("[blue]Publisher[/]");
            table.AddColumn("[blue]Publish Date[/]");
            table.AddColumn("[blue]Location[/]");

            var newspapers = MockDatabase.LibraryItems.OfType<Newspaper>();

            foreach (var newspaper in newspapers)
            {
                table.AddRow(
                    newspaper.Id.ToString(),
                    newspaper.Name,
                    newspaper.Publisher,
                    $"{newspaper.PublishDate:yyyy-MM-dd}",
                    newspaper.Location
                );
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        public void AddItem()
        {
            var title = AnsiConsole.Ask<string>("[blue]Enter the [white]title[/] of the newspaper to add:[/]");
            var publisher = AnsiConsole.Ask<string>("[blue]Enter the [white]publisher[/] of the newspaper:[/]");
            var publishDate = AnsiConsole.Ask<DateTime>("[blue]Enter the [white]publish date[/] of the newspaper (yyyy-MM-dd):[/]");
            var location = AnsiConsole.Ask<string>("[blue]Enter the [white]location[/] of the newspaper:[/]");

            if (MockDatabase.LibraryItems.OfType<Newspaper>().Any(n => n.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                AnsiConsole.MarkupLine("\n[red]This newspaper already exists![/] =(");
            }
            else
            {
                var newNewspaper = new Newspaper(MockDatabase.LibraryItems.Count + 1, title, publisher, publishDate, location);
                MockDatabase.LibraryItems.Add(newNewspaper);
                AnsiConsole.MarkupLine("\n[green]Newspaper added successfully![/] =)");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        public void DeleteItem()
        {
            if (MockDatabase.LibraryItems.OfType<Newspaper>().Count() == 0)
            {
                AnsiConsole.MarkupLine("[red]No newspapers available to delete![/] =(");
                Console.ReadKey();
                return;
            }

            var newspaperToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<Newspaper>()
                    .Title("Select a [blue]newspaper[/] to delete:")
                    .UseConverter(n => $"{n.Name} [grey](Published on {n.PublishDate:yyyy-MM-dd})[/]")
                    .AddChoices(MockDatabase.LibraryItems.OfType<Newspaper>()));

            if (MockDatabase.LibraryItems.Remove(newspaperToDelete))
            {
                AnsiConsole.MarkupLine("[green]Newspaper deleted successfully![/] =)");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Newspaper not found![/] =(");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }

}
