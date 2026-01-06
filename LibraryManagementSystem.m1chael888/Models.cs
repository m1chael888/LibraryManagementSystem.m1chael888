using Spectre.Console;

namespace LibraryManagementSystem.m1chael888
{
    internal class Models
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

        internal abstract class LibraryItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }

            protected LibraryItem(int id, string name, string location)
            {
                Id = id;
                Name = name;
                Location = location;
            }

            public abstract void DisplayDetails();
        }

        internal class Book : LibraryItem
        {
            internal string Author { get; set; }
            internal string Category { get; set; }
            internal int Pages { get; set; }

            internal Book(int id, string name, string author, string category, string location, int pages)
                : base(id, name, location)
            {
                Author = author;
                Category = category;
                Pages = pages;
            }

            public override void DisplayDetails()
            {
                var panel = new Panel(new Markup($"[bold]Book:[/] [cyan]{Name}[/] by [cyan]{Author}[/]") +
                                      $"\n[bold]Pages:[/] {Pages}" +
                                      $"\n[bold]Category:[/] [green]{Category}[/]" +
                                      $"\n[bold]Location:[/] [blue]{Location}[/]")
                {
                    Border = BoxBorder.Rounded
                };

                AnsiConsole.Write(panel);
            }
        }

        internal class Magazine : LibraryItem
        {
            public string Publisher { get; set; }
            public DateTime PublishDate { get; set; }
            public int IssueNumber { get; set; }

            public Magazine(int id, string name, string publisher, DateTime publishDate, string location, int issueNumber)
                : base(id, name, location)
            {
                Publisher = publisher;
                PublishDate = publishDate;
                IssueNumber = issueNumber;
            }

            public override void DisplayDetails()
            {
                var panel = new Panel(new Markup($"[bold]Magazine:[/] [cyan]{Name}[/] published by [cyan]{Publisher}[/]") +
                                      $"\n[bold]Publish Date:[/] {PublishDate:yyyy-MM-dd}" +
                                      $"\n[bold]Issue Number:[/] {IssueNumber}" +
                                      $"\n[bold]Location:[/] [blue]{Location}[/]")
                {
                    Border = BoxBorder.Rounded
                };

                AnsiConsole.Write(panel);
            }
        }

        internal class Newspaper : LibraryItem
        {
            public string Publisher { get; set; }
            public DateTime PublishDate { get; set; }

            public Newspaper(int id, string name, string publisher, DateTime publishDate, string location)
                : base(id, name, location)
            {
                Publisher = publisher;
                PublishDate = publishDate;
            }

            public override void DisplayDetails()
            {
                var panel = new Panel(new Markup($"[bold]Newspaper:[/] [cyan]{Name}[/] published by [cyan]{Publisher}[/]") +
                                      $"\n[bold]Publish Date:[/] {PublishDate:yyyy-MM-dd}" +
                                      $"\n[bold]Location:[/] [blue]{Location}[/]")
                {
                    Border = BoxBorder.Rounded
                };

                AnsiConsole.Write(panel);
            }
        }
    }
}
