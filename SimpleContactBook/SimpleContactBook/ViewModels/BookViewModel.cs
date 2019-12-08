
using System.Linq;
using System.Windows.Input;
using SimpleContactBook.Services;
using SimpleContactBook.Utility;

namespace SimpleContactBook.ViewModels
{
    public class BookViewModel : ObservableObject
    {
        private IContactDataService _service;

        private ContactsViewModel _contactsVM;
        public ContactsViewModel ContactsVM
        {
            get { return _contactsVM; }
            set { OnPropertyChanged(ref _contactsVM, value); }   
        }

        public ICommand LoadContactsCommand { get; private set; }
        public ICommand LoadFavoritesCommand { get; private set; }

        public BookViewModel(IContactDataService service)
        {
            ContactsVM = new ContactsViewModel();
            _service = service;
            LoadContactsCommand = new RelayCommand(LoadContacts);
            LoadFavoritesCommand = new RelayCommand(LoadFavorites);
        }

        private void LoadContacts()
        {
            ContactsVM.LoadContacts(_service.GetContacts());
        }

        private void LoadFavorites()
        {
            var favorites = _service.GetContacts().Where(c => c.IsFavorite);
            ContactsVM.LoadContacts(favorites);
        }
    }
}
