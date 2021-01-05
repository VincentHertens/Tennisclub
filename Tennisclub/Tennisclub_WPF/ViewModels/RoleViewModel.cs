using System;
using Tennisclub_Common.RoleDTO;

namespace Tennisclub_WPF.ViewModels
{
    public class RoleViewModel : GenericViewModel
    {
        private RoleReadDto _role;
        private string _name;

        public RoleReadDto Role
        {
            get { return _role; }
            set { _role = value; OnPropertyChanged("Role"); Name = Role?.Name; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }       
    }
}
