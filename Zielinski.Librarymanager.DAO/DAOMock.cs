using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zielinski.Librarymanager.Core;
using Zielinski.Librarymanager.Interfaces;

namespace Zielinski.Librarymanager.DAO
{
    public class DAOMock : IDAO
    {
        private List<IShelf> _shelves;
        private List<IBook> _books;
      
        public int GetNextBookID()
        {
            return _books[_books.Count - 1].ID + 1;
        }
        public DAOMock()
        {
            _shelves = new List<IShelf>()
            {
                new Shelf{ ShelfLocation="Shelf_1"},
                new Shelf{ ShelfLocation="Shelf_2"},
                new Shelf{ ShelfLocation="Shelf_3"},
                new Shelf{ ShelfLocation="Shelf_4"},
            };

            _books = new List<IBook>()
            {
                new Book{ ID=1, Title="Inxxxxx Search of Lost Time", Author="Marcel Proust", ISBN="5491189464223", Shelf=_shelves[0]},
                new Book{ ID=2, Title="Don Quixote", Author="Miguel de Cervantes", ISBN="9404119132528", Shelf=_shelves[0]},
                new Book{ ID=3, Title="Ulysses", Author="James Joyce", ISBN="8721933243321", Shelf=_shelves[0]},
                new Book{ ID=4, Title="The Great Gatsby", Author="F. Scott Fitzgerald", ISBN="2442153434905", Shelf=_shelves[0]},
                new Book{ ID=5, Title="Moby Dick", Author="Herman Melville", ISBN="9840925840008", Shelf=_shelves[0]},
                new Book{ ID=6, Title="Hamlet", Author="William Shakespeare", ISBN="4973418371360", Shelf=_shelves[0]},
                new Book{ ID=7, Title="War and Peace", Author="Leo Tolstoy", ISBN="8943811866177", Shelf=_shelves[1]},
                new Book{ ID=8, Title="The Odyssey", Author="Homer", ISBN="5079028271212", Shelf=_shelves[1]},
                new Book{ ID=9, Title="One Hundred Years of Solitude", Author="Gabriel Garcia Marquez", ISBN="4877537207250", Shelf=_shelves[1]},
                new Book{ ID=10, Title="The Divine Comedy", Author="Dante Alighieri", ISBN="9460793383147", Shelf=_shelves[1]},
                new Book{ ID=11, Title="The Brothers Karamazov", Author="Fyodor Dostoyevsky", ISBN="2913079444215", Shelf=_shelves[1]},
                new Book{ ID=12, Title="Madame Bovary", Author="Gustave Flaubert", ISBN="4358432755844", Shelf=_shelves[1]},
                new Book{ ID=13, Title="The Adventures of Huckleberry Finn", Author="Mark Twain", ISBN="5591298948009", Shelf=_shelves[2]},
                new Book{ ID=14, Title="The Iliad", Author="Homer", ISBN="6771585136336", Shelf=_shelves[2]},
                new Book{ ID=15, Title="Lolita", Author="Vladimir Nabokov", ISBN="1331470879409", Shelf=_shelves[2]},
                new Book{ ID=16, Title="Crime and Punishment", Author="Fyodor Dostoyevsky", ISBN="5594505276691", Shelf=_shelves[2]},
                new Book{ ID=17, Title="Alice's Adventures in Wonderland", Author="Lewis Carroll", ISBN="8187822024479", Shelf=_shelves[2]},
                new Book{ ID=18, Title="Wuthering Heights", Author="Emily Brontë", ISBN="4808712590779", Shelf=_shelves[2]},
                new Book{ ID=19, Title="Pride and Prejudice", Author="Jane Austen", ISBN="9961009254805", Shelf=_shelves[3]},
                new Book{ ID=20, Title="The Catcher in the Rye", Author="J. D. Salinger", ISBN="7843868309462", Shelf=_shelves[3]},
                new Book{ ID=21, Title="The Sound and the Fury", Author="William Faulkner", ISBN="1657488371882", Shelf=_shelves[3]},
                new Book{ ID=22, Title="To the Lighthouse", Author="Virginia Woolf", ISBN="5310498362948", Shelf=_shelves[3]},
                new Book{ ID=23, Title="Heart of Darkness", Author="Joseph Conrad", ISBN="1456341152781", Shelf=_shelves[3]},
                new Book{ ID=24, Title="Anna Karenina", Author="Leo Tolstoy", ISBN="6845164434893", Shelf=_shelves[3]},
            };
        }

        public IEnumerable<IShelf> GetAllShelves()
        {
            return _shelves;
        }

        public IEnumerable<IBook> GetAllBooks()
        {
            return _books;
        }

        public IBook CreateEmptyBook()
        {
            return new Book();
        }

        public void SaveBook(IBook book)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].ID == book.ID)
                {
                    _books[i] = book;
                    return ;
                }
            }
            _books.Add(book);
        }

        public void SaveShelf(IShelf shelf)
        {
            _shelves.Add(shelf);
        }

        public void DeleteBook(int ID)
        {
            for (int i = 0; i < _books.Count; i++)
            {
                if (_books[i].ID == ID)
                {
                    _books.RemoveAt(i);
                }
            }
        }
    }
}
