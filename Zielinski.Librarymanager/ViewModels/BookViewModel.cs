using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zielinski.Librarymanager.Interfaces;

namespace Zielinski.Librarymanager.UI.ViewModels
{
    public class BookViewModel : ViewModelBase
    {
        private IBook _book;

        public BookViewModel(IBook book, IEnumerable<IShelf> enumerable)
        {
            _book = book;
            _shelves = new ObservableCollection<IShelf>(enumerable);
        }

        public int ID
        {
            get => _book.ID;
            set
            {
                _book.ID = value;
                OnPropertyChanged("ID");
            }
        }

        public string Author
        {
            get => _book.Author;
            set
            {
                _book.Author = value;
                OnPropertyChanged("Author");
            }
        }

        public string Title
        {
            get => _book.Title;
            set
            {
                _book.Title = value;
                OnPropertyChanged("Title");
            }
        }
        
        public string ISBN
        {
            get => _book.ISBN;
            set
            {
                _book.ISBN = value;
                OnPropertyChanged("ISBN");
            }
        }

        public IShelf Shelf
        {
            get => _book.Shelf;
            set
            {
                _book.Shelf = value;
                OnPropertyChanged("Shelf");
            }
        }

        private ObservableCollection<IShelf> _shelves;

        public ObservableCollection<IShelf> Shelves
        {
            get => _shelves;
        }
    }
}
