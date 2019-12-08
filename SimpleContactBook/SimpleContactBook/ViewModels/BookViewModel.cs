
using System.Windows.Input;
using SimpleContactBook.Utility;

namespace SimpleContactBook.ViewModels
{
    public class BookViewModel : ObservableObject
    {
        private ContactsViewModel _contactVM;
        public ContactsViewModel ContactsVM
        {
            get { return _contactVM; }
            set { OnPropertyChanged(ref _contactVM, value); }   
        }

        public ICommand LoadContactsCommand { get; private set; }
        public ICommand LoadFavoritesCommand { get; private set; }

        public BookViewModel()
        {
            ContactsVM = new ContactsViewModel();
            LoadContactsCommand = new RelayCommand(LoadContacts);
            LoadFavoritesCommand = new RelayCommand(LoadFavorites);
        }

        private void LoadContacts()
        {

        }

        private void LoadFavorites()
        {

        }
    }
}
