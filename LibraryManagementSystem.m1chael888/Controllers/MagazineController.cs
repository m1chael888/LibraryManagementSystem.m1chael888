using Spectre.Console;
using LibraryManagementSystem.m1chael888.Models;

namespace LibraryManagementSystem.m1chael888.Controllers
{
    internal class MagazineController : BaseController
    {
        public void ViewItems()
        {
            var table = new Table();

            table.Border(TableBorder.Rounded);
            table.AddColumn("[blue]ID[/]");
            table.AddColumn("[blue]Title[/]");
            table.AddColumn("[blue]Publisher[/]");
            table.AddColumn("[blue]Publish Date[/]");
            table.AddColumn("[blue]Issue Number[/]");
            table.AddColumn("[blue]Location[/]");

            var magazines = MockDatabase.LibraryItems.OfType<Magazine>();

            foreach (var magazine in magazines)
            {
                table.AddRow(
                    magazine.Id.ToString(),
                    magazine.Name,
                    magazine.Publisher,
                    $"{magazine.PublishDate:MMMM dd, yyyy}",
                    magazine.IssueNumber.ToString(),
                    magazine.Location
                );
            }

            AnsiConsole.Write(table);
            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        public void AddItem()
        {
            var title = AnsiConsole.Ask<string>("[blue]Enter the [white]title[/] of the magazine to add:[/]");
            var publisher = AnsiConsole.Ask<string>("[blue]Enter the [white]publisher[/] of the magazine:[/]");
            var publishDate = AnsiConsole.Ask<DateTime>("[blue]Enter the [white]publish date[/] of the magazine (yyyy-mm-dd):[/]");
            var location = AnsiConsole.Ask<string>("[blue]Enter the [white]location[/] of the magazine:[/]");
            var issueNumber = AnsiConsole.Ask<int>("[blue]Enter the [white]issue number[/] of the magazine:[/]");

            if (MockDatabase.LibraryItems.OfType<Magazine>().Any(m => m.Name.Equals(title, StringComparison.OrdinalIgnoreCase)))
            {
                AnsiConsole.MarkupLine("\n[red]This magazine already exists![/] =(");
            }
            else
            {
                var newMagazine = new Magazine(MockDatabase.LibraryItems.Count + 1, title, publisher, publishDate, location, issueNumber);
                MockDatabase.LibraryItems.Add(newMagazine);
                AnsiConsole.MarkupLine("\n[green]Magazine added successfully![/] =)");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        public void DeleteItem()
        {
            if (MockDatabase.LibraryItems.OfType<Magazine>().Count() == 0)
            {
                AnsiConsole.MarkupLine("[red]No magazines available to delete![/] =(");
                Console.ReadKey();
                return;
            }

            var magazineToDelete = AnsiConsole.Prompt(
                new SelectionPrompt<Magazine>()
                    .Title("Select a [blue]magazine[/] to delete:")
                    .UseConverter(m => $"{m.Name} [grey](Issue {m.IssueNumber})[/]")
                    .AddChoices(MockDatabase.LibraryItems.OfType<Magazine>()));

            if (MockDatabase.LibraryItems.Remove(magazineToDelete))
            {
                AnsiConsole.MarkupLine("[green]Magazine deleted successfully![/] =)");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Magazine not found![/] =(");
            }

            AnsiConsole.MarkupLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
    }
}
