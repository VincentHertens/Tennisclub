using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_UI.ViewModels
{
    public class MemberRolesViewModel : BaseViewModel
    {
        public int MemberId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
