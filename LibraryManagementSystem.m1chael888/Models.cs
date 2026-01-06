using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.m1chael888
{
    internal class Models
    {
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
