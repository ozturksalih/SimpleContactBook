using System;
using System.Collections;
using System.Collections.Generic;
using FinalProjectSalihOzturk.Entities;
using FinalProjectSalihOzturk.Helpers;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using FinalProjectSalihOzturk.DataAccess;

namespace FinalProjectSalihOzturk.Logic
{
    public class ContactsViewLogic :ObservableObject
    {
        private Contact _selectedContact;

        private IContactDal _dataAccess;

        private bool _isEditMode;
        public ObservableCollection<Contact> Contacts { get; private set; }
        public ObservableCollection<Contact> Birthdays { get; private set; }
        public ICommand EditCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand UpdateCommand { get; private set; }
        public ICommand AddCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }

        public ContactsViewLogic(IContactDal dataAccess)
        {
            this._dataAccess = dataAccess;

            EditCommand = new RelayCommand(Edit, CanEdit);
            SaveCommand = new RelayCommand(Save, IsEdit);
            UpdateCommand = new RelayCommand(Update);
            AddCommand = new RelayCommand(Add);
            DeleteCommand = new RelayCommand(Delete, CanDelete);
        }

        public void GetContacts(IEnumerable<Contact> contacts)
        {
            Contacts = new ObservableCollection<Contact>(contacts);
            OnPropertyChanged("Contacts");
            OnPropertyChanged("Birthdays");
        }

        public void GetBirthdays(IEnumerable<Contact> contacts)
        {
            Birthdays = new ObservableCollection<Contact>(contacts);
            OnPropertyChanged("Contacts");
            OnPropertyChanged("Birthdays");
        }

        private bool CanDelete()
        {
            return SelectedContact != null;
        }

        private void Delete()
        {
            Contacts.Remove(SelectedContact);
            Save();
        }

        private void Add()
        {
            var newContact = new Contact
            {
                Name = "N/A",
                Surname = "N/A",
                Email = "N/A",
                PhoneNumber = "N/A",
                DateOfBirth = DateTime.Now

            };
            Contacts.Add(newContact);
            SelectedContact = newContact;
        }

        private void Update()
        {
            _dataAccess.Save(Contacts);
        }

        private bool IsEdit()
        {
            return IsEditMode;
        }

        private void Save()
        {
            _dataAccess.Save(Contacts);
            IsEditMode = false;
            OnPropertyChanged("SelectedContact");

        }

        private bool CanEdit()
        {
            if (SelectedContact == null)
                return false;
            return !IsEditMode;
        }

        private void Edit()
        {
            IsEditMode = true;
        }

        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set { OnPropertyChanged(ref _selectedContact, value); }
        }

        

        public bool IsEditMode
        {
            get { return _isEditMode; }
            set
            {
                OnPropertyChanged(ref _isEditMode, value);
                OnPropertyChanged("IsDisplayMode");
            }
        }
        public bool IsDisplayMode
        {
            get { return !_isEditMode; }
        }
    }
}