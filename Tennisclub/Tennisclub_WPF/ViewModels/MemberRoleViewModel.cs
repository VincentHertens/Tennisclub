using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_WPF.ViewModels
{
    public class MemberRoleViewModel : GenericViewModel
    {
        private DateTime? _addStartDate;

        public DateTime? AddStartDate
        {
            get { return _addStartDate; }
            set { _addStartDate = value; OnPropertyChanged("AddStartDate"); }
        }

        private DateTime? _updateMemberEndDate;

        public DateTime? UpdateMemberEndDate
        {
            get { return _updateMemberEndDate; }
            set { _updateMemberEndDate = value; OnPropertyChanged("UpdateMemberEndDate"); }
        }

        private DateTime? _updateRoleEndDate;

        public DateTime? UpdateRoleEndDate
        {
            get { return _updateRoleEndDate; }
            set { _updateRoleEndDate = value; OnPropertyChanged("UpdateRoleEndDate"); }
        }

    }
}
