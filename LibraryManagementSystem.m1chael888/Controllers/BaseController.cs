using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.m1chael888.Controllers
{
    internal abstract class BaseController
    {
        protected void DisplayMessage(string message, string color = "white")
        {
            AnsiConsole.MarkupLine($"[{color}]{message}[/]");
        }
    }
}
