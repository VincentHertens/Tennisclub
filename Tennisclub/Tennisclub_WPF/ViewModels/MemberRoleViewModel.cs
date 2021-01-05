using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_WPF.ViewModels
{
    public class MemberRoleViewModel : GenericViewModel
    {
        private DateTime? _addStartDate;
        private DateTime? _updateMemberEndDate;
        private DateTime? _updateRoleEndDate;

        public DateTime? AddStartDate
        {
            get { return _addStartDate; }
            set { _addStartDate = value; OnPropertyChanged("AddStartDate"); }
        }

        public DateTime? UpdateMemberEndDate
        {
            get { return _updateMemberEndDate; }
            set { _updateMemberEndDate = value; OnPropertyChanged("UpdateMemberEndDate"); }
        }

        public DateTime? UpdateRoleEndDate
        {
            get { return _updateRoleEndDate; }
            set { _updateRoleEndDate = value; OnPropertyChanged("UpdateRoleEndDate"); }
        }
    }
}
