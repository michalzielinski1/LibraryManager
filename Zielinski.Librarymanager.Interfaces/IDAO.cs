using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zielinski.Librarymanager.Interfaces
{
    public interface IDAO
    {
        int GetNextBookID();
        void SaveBook(IBook book);
        void DeleteBook(int ID);
        void SaveShelf(IShelf shelf);
        IEnumerable<IShelf> GetAllShelves();
        IEnumerable<IBook> GetAllBooks();
        IBook CreateEmptyBook();
    }
}
