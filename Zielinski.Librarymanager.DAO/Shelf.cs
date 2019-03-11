using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zielinski.Librarymanager.Core;
using Zielinski.Librarymanager.Interfaces;

namespace Zielinski.Librarymanager.DAO
{
    public class Shelf : IShelf
    {
        public string ShelfLocation { get; set; }
        public override string ToString()
        {
            return ShelfLocation.ToString();
        }
    }
}
