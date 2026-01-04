using Spectre.Console;
using static LibraryManagementSystem.m1chael888.BooksController;
using static LibraryManagementSystem.m1chael888.Enums;

namespace LibraryManagementSystem.m1chael888
{
    internal class UserInterface
    {
        internal static void MainMenu()
        {
            while (true)
            {
                Console.Clear();

                var choice = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuOption>()
                    .Title("[blue]What do you want to do next?[/]")
                    .AddChoices(Enum.GetValues<MenuOption>())
                    .WrapAround(true));

                switch (choice)
                {
                    case MenuOption.ViewBooks:
                        ViewBooks();
                        break;
                    case MenuOption.AddBook:
                        AddBook();
                        break;
                    case MenuOption.DeleteBook:
                        DeleteBook();
                        break;
                    case MenuOption.CloseApp:
                        AnsiConsole.MarkupLine("[blue]Goodbye[/] o/");
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
