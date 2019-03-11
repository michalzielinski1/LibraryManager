using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zielinski.Librarymanager.Interfaces;
using Zielinski.Librarymanager.DAO;

namespace Zielinski.Librarymanager.BLC
{
    public class BLC
    {
        private IDAO dao;
        public int nextID { get; }

        public BLC(string dbName)
        {
            Assembly a = Assembly.UnsafeLoadFrom(dbName);

            Type daoToCreate = null;
            Type daoType = typeof(IDAO);

            foreach (var t in a.GetTypes())
            {
                foreach (var i in t.GetInterfaces())
                {
                    if (i == daoType)
                    {
                        daoToCreate = t;
                    }
                }
            }
            dao = (IDAO)Activator.CreateInstance(daoToCreate, new object[] { });
        }

        public int GetNextBookID()
        {
            return dao.GetNextBookID();
        }

        public void SaveBook(Book book)
        {
            dao.SaveBook(book);
        }

        public void SaveShelf(Shelf shelf)
        {
            dao.SaveShelf(shelf);
        }

        public void DeleteBook(int ID)
        {
            dao.DeleteBook(ID);
        }

        public IEnumerable<IBook> GetBooks()
        {
            return dao.GetAllBooks();
        }

        public IEnumerable<IShelf> GetShelves()
        {
            return dao.GetAllShelves();
        }

        public IBook CreateEmptyBook()
        {
            return dao.CreateEmptyBook();
        }
    }
}
