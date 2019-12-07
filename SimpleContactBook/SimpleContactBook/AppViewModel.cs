
using SimpleContactBook.Utility;
using SimpleContactBook.ViewModels;

namespace SimpleContactBook
{
    public class AppViewModel : ObservableObject
    {
        #region Variables
        private object _currentView;
        private BookViewModel _bookVM;

        #endregion

        #region Properties

        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        public BookViewModel BookVM
        {
            get { return _bookVM; }
            set { OnPropertyChanged(ref _bookVM, value); }
        }

        #endregion

        #region Constructor

        public AppViewModel()
        {
            BookVM = new BookViewModel();
            CurrentView = BookVM;
        }

        #endregion
    }
}
