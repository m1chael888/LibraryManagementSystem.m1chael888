using Spectre.Console;
using LibraryManagementSystem.m1chael888.Controllers;
using static LibraryManagementSystem.m1chael888.Enums;

namespace LibraryManagementSystem.m1chael888
{
    internal class UserInterface
    {
        private readonly BooksController booksController = new BooksController();
        private readonly MagazineController magazinesController = new MagazineController();
        private readonly NewspaperController newspapersController = new NewspaperController();

        internal void MainMenu()
        {
            while (true)
            {
                Console.Clear();

                var optionChoice = AnsiConsole.Prompt(
                    new SelectionPrompt<MenuOption>()
                    .Title("[blue]What do you want to do next?[/]")
                    .AddChoices(Enum.GetValues<MenuOption>())
                    .WrapAround(true));

                if (optionChoice == MenuOption.CloseApp)
                {
                    AnsiConsole.MarkupLine("[blue]Goodbye[/] o/");
                    Environment.Exit(0);
                }

                var typeChoice = AnsiConsole.Prompt(
                new SelectionPrompt<ItemType>()
                .Title("[blue]Select the type of item:[/]")
                .AddChoices(Enum.GetValues<ItemType>())
                .WrapAround(true));

                switch (optionChoice)
                {
                    case MenuOption.ViewItems:
                        ViewItems(typeChoice);
                        break;
                    case MenuOption.AddItem:
                        AddItem(typeChoice);
                        break;
                    case MenuOption.DeleteItem:
                        DeleteItem(typeChoice);
                        break;
                }
            }
        }

        private void ViewItems(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Book:
                    booksController.ViewItems();
                    break;
                case ItemType.Magazine:
                    magazinesController.ViewItems();
                    break;
                case ItemType.Newspaper:
                    newspapersController.ViewItems();
                    break;
            }
        }

        private void AddItem(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Book:
                    booksController.AddItem();
                    break;
                case ItemType.Magazine:
                    magazinesController.AddItem();
                    break;
                case ItemType.Newspaper:
                    newspapersController.AddItem();
                    break;
            }
        }

        private void DeleteItem(ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Book:
                    booksController.DeleteItem();
                    break;
                case ItemType.Magazine:
                    magazinesController.DeleteItem();
                    break;
                case ItemType.Newspaper:
                    newspapersController.DeleteItem();
                    break;
            }
        }
    }
}
