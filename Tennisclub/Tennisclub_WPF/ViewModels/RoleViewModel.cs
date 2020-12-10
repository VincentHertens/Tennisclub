using System;
using System.Collections.Generic;
using System.Text;
using Tennisclub_Common.MemberRoleDTO;
using Tennisclub_Common.RoleDTO;

namespace Tennisclub_WPF.ViewModels
{
    public class RoleViewModel : GenericViewModel
    {
        private RoleReadDto _role;

        public RoleReadDto Role
        {
            get { return _role; }
            set { _role = value; OnPropertyChanged("Role"); Name = Role?.Name; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }


        //private MemberRoleReadDto _memberRole;

        //public MemberRoleReadDto MemberRole
        //{
        //    get { return _memberRole; }
        //    set { _memberRole = value; OnPropertyChanged("MemberRole"); EndDate = MemberRole?.EndDate; }
        //}

        //private DateTime? _endDate;

        //public DateTime? EndDate
        //{
        //    get { return _endDate; }
        //    set { _endDate = value; OnPropertyChanged("EndDate"); }
        //}


    }
}
