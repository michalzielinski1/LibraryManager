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
    public class ShelfViewModel : ViewModelBase
    {
        private IShelf _shelf;

        public ShelfViewModel(IShelf shelf)
        {
            _shelf = shelf;
        }

        public string ShelfLocation
        {
            get => _shelf.ShelfLocation;
            set
            {
                _shelf.ShelfLocation = value;
                OnPropertyChanged("ShelfLocation");
            }
        }
    }
}
