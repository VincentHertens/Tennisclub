using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tennisclub_Common.GenderDTO;
using Tennisclub_Common.MemberDTO;
using Tennisclub_WPF.Commands;

namespace Tennisclub_WPF.ViewModels
{
    public class MemberViewModel : GenericViewModel
    {
        private MemberReadDto _member;

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

        private string _federationNr;

        public string FederationNr
        {
            get { return _federationNr; }
            set { _federationNr = value; OnPropertyChanged("FederationNr"); }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; OnPropertyChanged("FirstName"); }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }

        private DateTime? _birthDate;

        public DateTime? BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; OnPropertyChanged("BirthDate"); }
        }

        private string _address;

        public string Address
        {
            get { return _address; }
            set { _address = value; OnPropertyChanged("Address"); }
        }

        private string _number;

        public string Number
        {
            get { return _number; }
            set { _number = value; OnPropertyChanged("Number"); }
        }

        private string _addition;

        public string Addition
        {
            get { return _addition; }
            set { _addition = value; OnPropertyChanged("Addition"); }
        }

        private string _zipcode;

        public string Zipcode
        {
            get { return _zipcode; }
            set { _zipcode = value; OnPropertyChanged("Zipcode"); }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; OnPropertyChanged("City"); }
        }

        private string _phoneNr;

        public string PhoneNr
        {
            get { return _phoneNr; }
            set { _phoneNr = value; OnPropertyChanged("PhoneNr"); }
        }

        /*        public MemberViewModel()
                {
                    _ = LoadMembers();
                    _ = LoadGenders();
                }

                public async Task LoadMembers()
                {
                    MembersCollection = await WebAPI.Get<List<MemberReadDto>>("members");
                }

                public async Task LoadGenders()
                {
                    GendersCollection = await WebAPI.Get<List<GenderReadDto>>("genders");
                }

                private List<MemberReadDto> _membersCollection;

                public List<MemberReadDto> MembersCollection
                {
                    get { return _membersCollection; }
                    set
                    {
                        _membersCollection = value;
                        OnPropertyChanged("MembersCollection");
                    }
                }

                private List<GenderReadDto> _gendersCollection;

                public List<GenderReadDto> GendersCollection
                {
                    get { return _gendersCollection; }
                    set 
                    { 
                        _gendersCollection = value;
                        OnPropertyChanged("GendersCollection");
                    }
                }  */
    }
}
