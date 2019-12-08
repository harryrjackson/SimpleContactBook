﻿
using SimpleContactBook.Utility;
using SimpleContactBook.Models;
using System.Collections.ObjectModel;
using System.Collections.Generic;

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

        public ObservableCollection<Contact> Contacts { get; private set; }

        public ContactsViewModel()
        {

        }

        public void LoadContacts(IEnumerable<Contact> contacts)
        {
            Contacts = new ObservableCollection<Contact>(contacts);
            OnPropertyChanged(nameof(Contacts));
        }
    }
}
