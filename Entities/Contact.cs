using System;
using System.ComponentModel;
using FinalProjectSalihOzturk.Helpers;

namespace FinalProjectSalihOzturk.Entities
{
    public class Contact :ObservableObject, INotifyPropertyChanged, IEntity
    {
        

        private string _name;
        public string Name
        {
            get { return _name; }
            set { OnPropertyChanged(ref _name, value); }
        }

        private string _surname;

        public string Surname
        {
            get { return _surname; }
            set
            {
                OnPropertyChanged(ref _surname, value);
            }
        }
        private DateTime _dateOfBirth;

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                OnPropertyChanged(ref _dateOfBirth, value);
                OnPropertyChanged("Age");
            }
        }

        private int _age;

        public int Age
        {
            get { return GetAge(DateOfBirth); }
            set
            {
                GetAge(DateOfBirth);

            }
        }
        public int GetAge(DateTime _dateOfBirth)
        {
            var today = DateTime.Today;
            
            var age = today.Year - _dateOfBirth.Year;
            
            if (_dateOfBirth.Date > today.AddYears(-age)) age--;
            this._age = age;
            return age;
        }

        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { OnPropertyChanged(ref _phoneNumber, value); }
        }

        private string _email;
        

        public string Email
        {
            get { return _email; }
            set { OnPropertyChanged(ref _email, value); }
        }
    }
}