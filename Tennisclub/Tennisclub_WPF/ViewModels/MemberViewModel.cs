using System;
using Tennisclub_Common.MemberDTO;

namespace Tennisclub_WPF.ViewModels
{
    public class MemberViewModel : GenericViewModel
    {
        private MemberReadDto _member;
        private string _federationNr;
        private string _firstName;
        private string _lastName;
        private DateTime? _birthDate;
        private string _address;
        private string _number;
        private string _addition;
        private string _zipcode;
        private string _city;
        private string _phoneNr;

        public MemberReadDto Member
        {
            get { return _member; }
            set 
            { 
                _member = value; 
                OnPropertyChanged("Member");
                FederationNr = Member?.FederationNr;
                FirstName = Member?.FirstName;
                LastName = Member?.LastName;
                BirthDate = Member?.BirthDate;
                Address = Member?.Address;
                Number = Member?.Number;
                Addition = Member?.Addition;
                Zipcode = Member?.Zipcode;
                City = Member?.City;
                PhoneNr = Member?.PhoneNr;
            }
        }

        public string FederationNr
        {
            get { return _federationNr; }
            set { _federationNr = value; OnPropertyChanged("FederationNr"); }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }

        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; OnPropertyChanged("BirthDate"); }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged("Address"); }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged("Number"); }
        }

        public string Addition
        {
            get { return _addition; }
            set { _addition = value; OnPropertyChanged("Addition"); }
        }

        public string Zipcode
        {
            get { return _zipcode; }
            set { _zipcode = value; OnPropertyChanged("Zipcode"); }
        }

        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged("City"); }
        }

        public string PhoneNr
        {
            get { return _phoneNr; }
            set { _phoneNr = value; OnPropertyChanged("PhoneNr"); }
        }   
    }
}
