using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zielinski.Librarymanager.DAO;
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

        [Required(ErrorMessage = "Book should have an ID")]
        public int ID
        {
            get => _book.ID;
            set
            {
                _book.ID = value;
                OnPropertyChanged("ID");
            }
        }

        [Required(ErrorMessage = "Book should have an author")]
        public string Author
        {
            get => _book.Author;
            set
            {
                _book.Author = value;
                Validate();
                OnPropertyChanged("Author");
            }
        }

        [Required(ErrorMessage = "Book should have a title")]
        public string Title
        {
            get => _book.Title;
            set
            {
                _book.Title = value;
                Validate();
                OnPropertyChanged("Title");
            }
        }

        public string ISBN
        {
            get => _book.ISBN;
            set
            {
                _book.ISBN = value;
                Validate();
                OnPropertyChanged("ISBN");
            }
        }

        [Required(ErrorMessage = "Book should be on a shelf")]
        public IShelf Shelf
        {
            get => _book.Shelf;
            set
            {
                _book.Shelf = value;
                Validate();
                OnPropertyChanged("Shelf");
            }
        }


        private ObservableCollection<IShelf> _shelves;

        public ObservableCollection<IShelf> Shelves
        {
            get => _shelves;
        }

        public void Validate()
        {
            var validationContext = new ValidationContext(this, null, null);
            var validationResults = new List<ValidationResult>();

            Validator.TryValidateObject(this, validationContext, validationResults, true);

            foreach (var kv in _errors.ToList())
            {
                if (validationResults.All(r => r.MemberNames.All(m => m != kv.Key)))
                {
                    _errors.Remove(kv.Key);
                    RaiseErrorChanged(kv.Key);
                }
            }

            var q = from r in validationResults
                    from m in r.MemberNames
                    group r by m into g
                    select g;

            foreach (var prop in q)
            {
                var messages = prop.Select(r => r.ErrorMessage).ToList();

                if (_errors.ContainsKey(prop.Key))
                {
                    _errors.Remove(prop.Key);
                }
                _errors.Add(prop.Key, messages);

                RaiseErrorChanged(prop.Key);
            }
        }
    }
}
