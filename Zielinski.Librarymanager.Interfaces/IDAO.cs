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
        IEnumerable<IShelf> GetAllShelves();
        IEnumerable<IBook> GetAllBooks();
        IBook CreateEmptyBook();
    }
}
