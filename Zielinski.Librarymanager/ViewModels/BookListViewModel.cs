using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Zielinski.Librarymanager.DAO;
using Zielinski.Librarymanager.Interfaces;
using Zielinski.Librarymanager.BLC;


namespace Zielinski.Librarymanager.UI.ViewModels
{
    public class BookListViewModel : ViewModelBase
    {
        public ObservableCollection<BookViewModel> Books { get; set; } = new ObservableCollection<BookViewModel>();
        private ListCollectionView _view;
        private BLC.BLC blc;
        private RelayCommand _filterDataCommand;
        public RelayCommand FilterDataCommand { get => _filterDataCommand; }
        public string FilterValue { get; set; }
        public BookListViewModel()
        {
            OnPropertyChanged("Books");
            blc = new BLC.BLC();
            GetAllBooks();
            _view = (ListCollectionView)CollectionViewSource.GetDefaultView(Books);
            _filterDataCommand = new RelayCommand(param => this.FilterData());
            _addNewBookCommand = new RelayCommand(param => this.AddNewBook(),
                                                  param => this.CanAddNewBook());

            _saveBookCommand = new RelayCommand(param => this.SaveBook(),
                                                param => this.CanSaveBook());

            _saveShelfCommand = new RelayCommand(param => this.SaveShelf(),
                                                param => this.CanSaveShelf());


            _deleteBookCommand = new RelayCommand(param => this.DeleteBook(),
                                    param => this.CanDeleteBook());
        }

        private void GetAllBooks()
        {
            Books.Clear();
            foreach (var book in blc.GetBooks())
            {
                Books.Add(new BookViewModel(book, blc.GetShelves()));
            }
        }

        private void FilterData()
        {
            if (string.IsNullOrEmpty(FilterValue))
            {
                _view.Filter = null;
            }
            else
            {
                _view.Filter = (c) => ((BookViewModel)c).Title.Contains(FilterValue);
            }
        }

        private BookViewModel _editedBook = null;
        public BookViewModel EditedBook
        {
            get => _editedBook;
            set
            {
                _editedBook = value;
                OnPropertyChanged(nameof(EditedBook));
            }
        }

        private void AddNewBook()
        {
            EditedBook = new BookViewModel(new Book(), blc.GetShelves());
            EditedBook.ID = blc.GetNextBookID();
            EditedBook.Title = "NewBook";
            Books.Add(EditedBook);
            SelectedBook = EditedBook;
        }

        private RelayCommand _addNewBookCommand;

        public RelayCommand AddNewBookCommand
        {
            get => _addNewBookCommand;
        }

        private bool CanAddNewBook()
        {
            if (EditedBook != null)
                return false;
            return true;
        }

        private RelayCommand _saveBookCommand;

        public RelayCommand SaveBookCommand
        {
            get => _saveBookCommand;
        }

        private void SaveBook()
        {
            blc.SaveBook(new Book { ID = SelectedBook.ID,
                                    Title = SelectedBook.Title,
                                    Author = SelectedBook.Author,
                                    ISBN = SelectedBook.ISBN,
                                    Shelf =  SelectedBook.Shelf });
            EditedBook = null;
        }

        private ShelfViewModel _editedShelf = new ShelfViewModel(new Shelf { ShelfLocation="New Shelf"});
        public ShelfViewModel EditedShelf
        {
            get => _editedShelf;
            set
            {
                _editedShelf = value;
                OnPropertyChanged(nameof(EditedShelf));
            }
        }

        private RelayCommand _saveShelfCommand;

        public RelayCommand SaveShelfCommand
        {
            get => _saveShelfCommand;
        }

        private void SaveShelf()
        {
            blc.SaveShelf(new Shelf{ShelfLocation=EditedShelf.ShelfLocation});
            EditedShelf = new ShelfViewModel(new Shelf { ShelfLocation = "New Shelf"});
            GetAllBooks();
        }

        private bool CanSaveShelf()
        {
            if (EditedShelf != null)
            {
                return true;
            }
            return false;
        }
        private BookViewModel selectedBook;

        public BookViewModel SelectedBook
        {
            get => selectedBook;
            set
            {
                BookViewModel previouslyselectedBook = selectedBook;
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }

        private bool CanSaveBook()
        {
            if ((EditedBook != null) &&
                !EditedBook.HasErrors)
            {
                return true;
            }

            return false;
        }

        private RelayCommand _deleteBookCommand;

        public RelayCommand DeleteBookCommand
        {
            get => _deleteBookCommand;
        }

        private bool CanDeleteBook()
        {
            if (SelectedBook != null)
            {
                return true;
            }
            return false;
        }

        private void DeleteBook()
        {
            blc.DeleteBook(selectedBook.ID);
            if (EditedBook != null && selectedBook.ID == EditedBook.ID)
            {
                EditedBook = null;
            }
            Books.Remove(SelectedBook);
        }

        public bool IsDirty
        {
            get; set;
        }
    }
}
