using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManagementSystem.m1chael888
{
    internal class Book
    {
        public string Name { get; set; } = "Unknown";
        public int Pages { get; set; } = 0; 

        public Book(string name, int pages)
        {
            Name = name;
            Pages = pages;
        }
    }
}
