
using SimpleContactBook.Utility;
using SimpleContactBook.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Windows.Input;
using System;

namespace SimpleContactBook.ViewModels
{
    public class ContactsViewModel : ObservableObject
    {
        private Contact _selectedContact;

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set { OnPropertyChanged(ref _selectedContact,  value); }
        }

        private bool _isEditMode;
        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                OnPropertyChanged(ref _isEditMode, value);
                OnPropertyChanged(nameof(IsDisplayMode));
            }
        }

        public bool IsDisplayMode
        {
            get { return !_isEditMode; }
        }

        public ObservableCollection<Contact> Contacts { get; private set; }

        public ICommand EditCommand { get; private set; }

        public ContactsViewModel()
        {
            EditCommand = new RelayCommand(Edit, CanEdit);
        }

        private bool CanEdit()
        {
            if (SelectedContact == null)
            {
                return false;
            }
            return !IsEditMode;
        }

        private void Edit()
        {
            IsEditMode = true;
        }

        public void LoadContacts(IEnumerable<Contact> contacts)
        {
            Contacts = new ObservableCollection<Contact>(contacts);
            OnPropertyChanged(nameof(Contacts));
        }
    }
}
