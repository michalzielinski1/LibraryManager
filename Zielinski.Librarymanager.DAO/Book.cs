﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zielinski.Librarymanager.Interfaces;

namespace Zielinski.Librarymanager.DAO
{
    public class Book : IBook
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public IShelf Shelf { get; set; }
    }
}
