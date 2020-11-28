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
