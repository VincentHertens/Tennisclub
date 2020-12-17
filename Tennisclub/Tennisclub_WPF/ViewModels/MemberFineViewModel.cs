using System;
using System.Collections.Generic;
using System.Text;

namespace Tennisclub_WPF.ViewModels
{
    public class MemberFineViewModel : GenericViewModel
    {
        private int _fineNumber;
        private string _amount;
        private DateTime? _handoutDate;
        private DateTime? _paymentDate;

        public int FineNumber
        {
            get { return _fineNumber; }
            set { _fineNumber = value; OnPropertyChanged("FineNumber"); }
        }

        public string Amount
        {
            get { return _amount; }
            set { _amount = value; OnPropertyChanged("Amount"); }
        }

        public DateTime? HandoutDate
        {
            get { return _handoutDate; }
            set { _handoutDate = value; OnPropertyChanged("HandoutDate"); }
        }

        public DateTime? PaymentDate
        {
            get { return _paymentDate; }
            set { _paymentDate = value; OnPropertyChanged("PaymentDate"); }
        }
    }
}
